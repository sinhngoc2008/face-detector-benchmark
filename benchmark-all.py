import cv2
import numpy as np
from face_detector import *
import time
import os
from tqdm import tqdm
import time
import argparse
import pathlib

def get_iou(boxA,boxB):
    # determine the (x, y)-coordinates of the intersection rectangle
	xA = max(boxA[0], boxB[0])
	yA = max(boxA[1], boxB[1])
	xB = min(boxA[2], boxB[2])
	yB = min(boxA[3], boxB[3])
	# compute the area of intersection rectangle
	interArea = max(0, xB - xA + 1) * max(0, yB - yA + 1)
	# compute the area of both the prediction and ground-truth
	# rectangles
	boxAArea = (boxA[2] - boxA[0] + 1) * (boxA[3] - boxA[1] + 1)
	boxBArea = (boxB[2] - boxB[0] + 1) * (boxB[3] - boxB[1] + 1)
	# compute the intersection over union by taking the intersection
	# area and dividing it by the sum of prediction + ground-truth
	# areas - the interesection area
	iou = interArea / float(boxAArea + boxBArea - interArea)
	# return the intersection over union value
	return iou


def extract_and_filter_data(splits,size='small'):
    # Extract bounding box ground truth from dataset annotations, also obtain each image path
    # and maintain all information in one dictionary
    bb_gt_collection = dict()

    for split in splits:
        # only read the new files i make with 180 samples.
        with open(
                os.path.join('dataset', 'wider_face_split',
                             '_wider_face_%s_%s_bbx_gt.txt' % (size,split)), 'r') as f:
            lines = f.readlines()

        for line in lines:
            line = line.split('\n')[0]
            if line.endswith('.jpg'):
                image_path = os.path.join('dataset', 'WIDER_%s' % (split),
                                          'images', line)
                bb_gt_collection[image_path] = []
            line_components = line.split(' ')
            if len(line_components) > 1:

                # Discard annotation with invalid image information, see dataset/wider_face_split/readme.txt for details
                if int(line_components[7]) != 1:
                    x1 = int(line_components[0])
                    y1 = int(line_components[1])
                    w = int(line_components[2])
                    h = int(line_components[3])

                    # In order to make benchmarking more valid, we discard faces with width or height less than 15 pixel,
                    # after reading and checking some part of the data (images), for our model, we dont need less than 70 pixel faces, 
                    #so ignoring all 70 pixels or smaller faces. 
                    if w > 70 and h > 70:
                        bb_gt_collection[image_path].append(
                            np.array([x1, y1, x1 + w, y1 + h]))

    return bb_gt_collection


def evaluate(method,face_detector, bb_gt_collection, iou_threshold):
    total_data = len(bb_gt_collection.keys())
    data_total_precision = 0
    data_total_inference_time = 0
    dir_path = str('system_benchmark/img/'+method)
    pathlib.Path(dir_path).mkdir(parents=True,exist_ok=True)
    # Evaluate face detector and iterate it over dataset
    for i, key in tqdm(enumerate(bb_gt_collection), total=total_data):
        image_data = cv2.imread(key)
        face_bbs_gt = np.array(bb_gt_collection[key])
        total_gt_face = len(face_bbs_gt)
        start_time = time.time()
        face_pred = face_detector.detect_face(image_data)
        inf_time = time.time() - start_time
        data_total_inference_time += inf_time

        ### Calc average IOU, Precision, and Average inferencing time ####
        total_iou = 0
        tp = 0
        pred_dict = dict()
        for gt in face_bbs_gt:
            max_iou_per_gt = 0
            cv2.rectangle(image_data, (gt[0], gt[1]), (gt[2], gt[3]),
                          (255, 0, 0), 2)
            for i, pred in enumerate(face_pred):
                if i not in pred_dict.keys():
                    pred_dict[i] = 0
                cv2.rectangle(image_data, (pred[0], pred[1]),
                              (pred[2], pred[3]), (0, 0, 255), 2)
                iou = get_iou(gt, pred)
                if iou > max_iou_per_gt:
                    max_iou_per_gt = iou
                if iou > pred_dict[i]:
                    pred_dict[i] = iou
            total_iou = total_iou + max_iou_per_gt
            
        if total_gt_face != 0:
            if len(pred_dict.keys()) > 0:
                for i in pred_dict:
                    if pred_dict[i] >= iou_threshold:
                        tp += 1
                precision = float(tp) / float(total_gt_face)

            else:
                precision = 0

            image_average_iou = total_iou / total_gt_face
            image_average_precision =precision

            data_total_precision += image_average_precision
        
        cv2.imwrite(str(dir_path+'/'+key.split('/')[-1]),image_data)
    result = dict()
    result['mean_average_precision'] = float(data_total_precision) / float(
        total_data)
    result['average_inferencing_time'] = float(
        data_total_inference_time) / float(total_data)
    
    return result


def get_args():
    parser = argparse.ArgumentParser(
        description=
        "This script is used to evaluate the face detector on WIDER face dataset",
        formatter_class=argparse.ArgumentDefaultsHelpFormatter)
    parser.add_argument(
        "--iou_threshold",
        "-t",
        type=float,
        default=0.5,
        help=
        "IOU threshold used to determine whether the prediction is matched the ground truth, should be float between 0 and 1"
    )

    args = parser.parse_args()
    return args


def main():
    args = get_args()
    splits = ['val']
    iou_threshold = args.iou_threshold
    pathlib.Path('system_benchmark/img').mkdir(parents=True,exist_ok=True)
    # Current available method in this repo
    method_list = [
        #'opencv_haar','mobilenet_ssd' ,'dlib_hog', 
        'yolo',#'mtcnn', 'dlib_cnn'
    ]
    
    for method in method_list:
        if method == 'opencv_haar':
            face_detector = OpenCVHaarFaceDetector(scaleFactor=1.3,minNeighbors=5,model_path='models/haarcascade_frontalface_default.xml')
            print('Method Name: ',method)
            data_dict = extract_and_filter_data(splits)
            result = evaluate(method,face_detector, data_dict, iou_threshold)
            print('mAP = %s' % (str(result['mean_average_precision'])))
            print('Average inference time = %s' % (str(result['average_inferencing_time'])))
        if method == 'dlib_hog':
            face_detector = DlibHOGFaceDetector(nrof_upsample=0, det_threshold=-0.2)
            print('Method Name: ',method)
            data_dict = extract_and_filter_data(splits)
            result = evaluate(method,face_detector, data_dict, iou_threshold)
            print('mAP = %s' % (str(result['mean_average_precision'])))
            print('Average inference time = %s' % (str(result['average_inferencing_time'])))
        if method == 'dlib_cnn':
            face_detector = DlibCNNFaceDetector(
            nrof_upsample=0, model_path='models/mmod_human_face_detector.dat')
            print('Method Name: ',method)
            data_dict = extract_and_filter_data(splits)
            result = evaluate(method,face_detector, data_dict, iou_threshold)
            print('mAP = %s' % (str(result['mean_average_precision'])))
            print('Average inference time = %s' % (str(result['average_inferencing_time'])))
        if method == 'mtcnn':
            np_load_old = np.load
            np.load = lambda *a, **k: np_load_old(*a,allow_pickle=True,**k)
            face_detector = TensorflowMTCNNFaceDetector(model_path='models/mtcnn')
            np.load = np_load_old
            print('Method Name: ',method)
            data_dict = extract_and_filter_data(splits)
            result = evaluate(method,face_detector, data_dict, iou_threshold)
            print('mAP = %s' % (str(result['mean_average_precision'])))
            print('Average inference time = %s' % (str(result['average_inferencing_time'])))
        if method == 'mobilenet_ssd':
            face_detector = TensoflowMobilNetSSDFaceDector(
            det_threshold=0.3,
            model_path='models/ssd/frozen_inference_graph_face.pb')
            print('Method Name: ',method)
            data_dict = extract_and_filter_data(splits)
            result = evaluate(method,face_detector, data_dict, iou_threshold)
            print('mAP = %s' % (str(result['mean_average_precision'])))
            print('Average inference time = %s' % (str(result['average_inferencing_time'])))
        if method == 'yolo':
            face_detector = OpenCVYoloFace()
            print('Method Name: ',method)
            data_dict = extract_and_filter_data(splits)
            result = evaluate(method,face_detector, data_dict, iou_threshold)
            print('mAP = %s' % (str(result['mean_average_precision'])))
            print('Average inference time = %s' % (str(result['average_inferencing_time'])))


if __name__ == '__main__':
    main()
