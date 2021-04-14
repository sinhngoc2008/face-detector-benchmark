import numpy as np
import cv2
import os
from face_detector import *
from recog import *

face_detector = TensoflowMobilNetSSDFaceDector(
            det_threshold=0.3,
            model_path='models/ssd/frozen_inference_graph_face.pb')

feature_extractor = Facenet()
searcher = FaceSearching()

# Write some Text

font                   = cv2.FONT_HERSHEY_SIMPLEX
fontScale              = .75
fontColor              = (255,255,255)
lineType               = 1

def image_processing(face_img,threshold):
    embed = feature_extractor.make_face_features(face_img)
    person_idx,person,dis_high = searcher.linear_search(embed)
    if dis_high >= threshold:
        return person_idx,person,dis_high
    else:
        return -1, "UNKNOWN", -1

cap = cv2.VideoCapture(0)

if not (cap.isOpened()):
    print('please connect the device')

else:
    timer = 0
    text = 'INIT'
    while(True):
        # Capture frame-by-frame
        ret, frame = cap.read()
        #print('Image Size',frame.shape)
        
        if ret == False:
            break;
        timer = timer + 1
        if not os.path.exists('img_cache'):
            os.mkdir('img_cache')
        face_pred = face_detector.detect_face(frame)

        for i, pred in enumerate(face_pred):
            cv2.rectangle(frame, (pred[0], pred[1]),(pred[2], pred[3]), (255,255,255), 1)
            if (timer % 30) == 0:
               data = image_processing(frame[pred[1] : pred[3], pred[0] : pred[2]],.55)
               print(data)
               text = data[1]
               cv2.putText(frame,data[1],(pred[0], pred[1]-10),font,fontScale,fontColor,lineType)
               cv2.imshow(data[1],frame[pred[1] : pred[3], pred[0] : pred[2]])
               #cv2.imwrite('img_cache/frame_'+str(timer+i)+'_.jpg',frame[pred[1] : pred[3], pred[0] : pred[2]])
        cv2.putText(frame,text,(pred[0], pred[1]-10),font,fontScale,fontColor,lineType)
   
        # Display the resulting frame
        cv2.imshow('XISOM VISON',frame)
        #print(frame.shape)
        if cv2.waitKey(1) & 0xFF == ord('q'):
            break;

# When everything done, release the capture
cap.release()
cv2.destroyAllWindows()