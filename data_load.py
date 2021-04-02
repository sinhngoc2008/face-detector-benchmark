import cv2
import numpy as np
from face_detector import *
import os
from tqdm import tqdm
import time
import argparse
from utils import *

font                   = cv2.FONT_HERSHEY_SIMPLEX
bottomLeftCornerOfText = (0,30)
fontScale              = 1
fontColor              = (255,255,255)
lineType               = 2

def get_iou(pred_box, gt_box):
    """
    pred_box : the coordinate for predict bounding box
    gt_box :   the coordinate for ground truth bounding box
    return :   the iou score
    the  left-down coordinate of  pred_box:(pred_box[0], pred_box[1])
    the  right-up coordinate of  pred_box:(pred_box[2], pred_box[3])
    """
    # 1.get the coordinate of inters
    ixmin = max(pred_box[0], gt_box[0])
    ixmax = min(pred_box[2], gt_box[2])
    iymin = max(pred_box[1], gt_box[1])
    iymax = min(pred_box[3], gt_box[3])

    iw = np.maximum(ixmax-ixmin+1., 0.)
    ih = np.maximum(iymax-iymin+1., 0.)

    # 2. calculate the area of inters
    inters = iw*ih

    # 3. calculate the area of union
    uni = ((pred_box[2]-pred_box[0]+1.) * (pred_box[3]-pred_box[1]+1.) +
           (gt_box[2] - gt_box[0] + 1.) * (gt_box[3] - gt_box[1] + 1.) -
           inters)

    # 4. calculate the overlaps between pred_box and gt_box
    iou = inters / uni

    return iou

def extract_and_filter_data(splits):
    # Extract bounding box ground truth from dataset annotations, also obtain each image path
    # and maintain all information in one dictionary
    bb_gt_collection = dict()

    for split in splits:
        with open(
                os.path.join('dataset', 'wider_face_split',
                             'wider_face_%s_bbx_gt.txt' % (split)), 'r') as f:
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
                    # we decide that face less than 15 pixel will not informative enough to be detected
                    if w > 30 and h > 30:
                        bb_gt_collection[image_path].append(
                            np.array([x1, y1, x1 + w, y1 + h]))

    return bb_gt_collection

def evaluate(face_detector, bb_gt_collection, iou_threshold):
    total_data = len(bb_gt_collection.keys())
    data_total_iou = 0
    data_total_precision = 0
    data_total_inference_time = 0

    # Evaluate face detector and iterate it over dataset
    i= 0
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
            cv2.rectangle(image_data, (gt[0], gt[1]), (gt[2], gt[3]),(0,255, 0), 1)
            for i, pred in enumerate(face_pred):
                if i not in pred_dict.keys():
                    pred_dict[i] = 0
                cv2.rectangle(image_data, (pred[0], pred[1]),(pred[2], pred[3]), (255,0,0), 1)
                iou = get_iou(gt, pred)
                if iou > max_iou_per_gt:
                    max_iou_per_gt = iou
                if iou > pred_dict[i]:
                    pred_dict[i] = iou
            total_iou = total_iou + max_iou_per_gt
        if total_gt_face != 0:
            if len(pred_dict.keys()) > 0:
                for i in pred_dict:
                    if pred_dict[i] >= 0.5:
                        tp = tp + 1
                precision = float(tp) / float(total_gt_face)

            else:
                precision = 0

            image_average_iou = total_iou / total_gt_face
            image_average_precision = precision

            data_total_iou = data_total_iou + image_average_iou
            data_total_precision = data_total_precision + image_average_precision
        else:
            continue
        
        cv2.putText(image_data,str(["AVG: ","{:1.3f}".format(image_average_iou),"Pres: ","{:1.3f}".format(image_average_precision),
                    "GTF: ",len(face_bbs_gt),"PTF: ",len(face_pred)]),
                    bottomLeftCornerOfText,font,fontScale,fontColor,lineType)
        cv2.imshow('Predicted Image',image_data)
        if cv2.waitKey(800) | 0xFF == ord('q'):
            continue
        cv2.destroyAllWindows()

    result = dict()
    result['average_iou'] = float(data_total_iou) / float(total_data)
    result['mean_average_precision'] = float(data_total_precision) / float(
        total_data)
    result['average_inferencing_time'] = float(
        data_total_inference_time) / float(total_data)

    return result
    
if __name__ == '__main__':
    splits = ['train', 'val']
    iou_threshold = 0.50
    #face_detector = TensoflowMobilNetSSDFaceDector(det_threshold=0.3,model_path='models/ssd/frozen_inference_graph_face.pb')
    #face_detector = OpenCVHaarFaceDetector(scaleFactor=1.3,minNeighbors=5,model_path='models/haarcascade_frontalface_default.xml')
    #np_load_old = np.load
    #np.load = lambda *a, **k: np_load_old(*a,allow_pickle=True,**k)
    #face_detector = TensorflowMTCNNFaceDetector(model_path='models/mtcnn')
    #np.load = np_load_old
    face_detector = OpenCVYoloFace()
    data_dict = extract_and_filter_data(splits)
    result = evaluate(face_detector, data_dict, iou_threshold)
    print('Average IOU = %s' % (str(result['average_iou'])))
    print('mAP = %s' % (str(result['mean_average_precision'])))
    print('Average inference time = %s' % (str(result['average_inferencing_time'])))