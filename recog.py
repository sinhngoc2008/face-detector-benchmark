from __future__ import print_function, division
import numpy as np
from numpy import dot
from numpy.linalg import norm

import tensorflow as tf

import cv2
import json
import os
from tensorflow.keras.models import Model,load_model
from tensorflow.keras.layers import Conv2D, Activation, Input, Add
from tensorflow.keras.layers import Dense, Flatten, Dropout
from tensorflow.keras.layers import MaxPooling2D


class FaceFeatureExtract():
    def __init__(self,model_weight='models/face/deepid_keras_weights.h5'):
        self.model_weight = model_weight
        self.model = self._make_model()
        
    def _make_model(self):
        myInput = Input(shape=(55, 47, 3))
        x = Conv2D(20, (4, 4), name='Conv1', activation='relu', input_shape=(55, 47, 3))(myInput)
        x = MaxPooling2D(pool_size=2, strides=2, name='Pool1')(x)
        x = Dropout(rate=.5, name='D1')(x)
 
        x = Conv2D(40, (3, 3), name='Conv2', activation='relu')(x)
        x = MaxPooling2D(pool_size=2, strides=2, name='Pool2')(x)
        x = Dropout(rate=.5, name='D2')(x)
 
        x = Conv2D(60, (3, 3), name='Conv3', activation='relu')(x)
        x = MaxPooling2D(pool_size=2, strides=2, name='Pool3')(x)
        x = Dropout(rate=.5, name='D3')(x)
 
        x1 = Flatten()(x)
        fc11 = Dense(160, name = 'fc11')(x1)
 
        x2 = Conv2D(80, (2, 2), name='Conv4', activation='relu')(x)
        x2 = Flatten()(x2)
        fc12 = Dense(160, name = 'fc12')(x2)
 
        y = Add()([fc11, fc12])
        y = Activation('relu', name = 'deepid')(y)
 
        model = Model(inputs=[myInput], outputs=y)

        #model.summary()

        model.compile(optimizer='adam', loss='mse',metrics=['accuracy'])
        model.load_weights(self.model_weight)
        
        
        return model
    
    def make_face_features(self,image):
        face_pixels = cv2.resize(image,(55, 47),cv2.INTER_AREA)
        # scale pixel values
        face_pixels = face_pixels.astype('float32')
        # standardize pixel values across channels (global)
        mean, std = face_pixels.mean(), face_pixels.std()
        face_pixels = (face_pixels - mean) / std
        # scale pixel values
        face_pixels = face_pixels.astype('float32')
        # standardize pixel values across channels (global)
        mean, std = face_pixels.mean(), face_pixels.std()
        face_pixels = (face_pixels - mean) / std
        face_pixels = np.reshape(face_pixels,(1,55,47,3))
        pred = self.model.predict(face_pixels)
        
        return np.reshape(pred,(160,))

class Facenet():
    def __init__(self,model_path ='models/facenet/model/facenet_keras.h5',
                 model_weight='models/facenet/weights/facenet_keras_weights.h5'):
        self.model_weight = model_weight
        self.model_path = model_path
        self.model = self._make_model()
        
    def _make_model(self):
        model = load_model(self.model_path)

        #model.summary()

        model.compile(optimizer='adam', loss='mse',metrics=['accuracy'])
        model.load_weights(self.model_weight)
        
        
        return model
    
    def make_face_features(self,image):
        face_pixels = cv2.resize(image,(160,160),cv2.INTER_AREA)
        # scale pixel values
        face_pixels = face_pixels.astype('float32')
        # standardize pixel values across channels (global)
        mean, std = face_pixels.mean(), face_pixels.std()
        face_pixels = (face_pixels - mean) / std
        # scale pixel values
        face_pixels = face_pixels.astype('float32')
        # standardize pixel values across channels (global)
        mean, std = face_pixels.mean(), face_pixels.std()
        face_pixels = (face_pixels - mean) / std
        face_pixels = np.reshape(face_pixels,(1,160,160,3))
        pred = self.model.predict(face_pixels)
        
        return np.reshape(pred,(128,))
    
class PersonList():
    def __init__(self,filename='recog_files/person_dict.xml'):
        self.filename = filename
        self.dict_list = self._load_file()
    
    def _load_file(self):
        if os.path.isfile(self.filename):
            return json.load(open(self.filename))
        else:
            with open(self.filename,'w+') as f:
                f.write(json.dumps({}))
            return json.load(open(self.filename))
    
    def add_new(self,name):
        if not name in self.dict_list:
        
            idx = len(self.dict_list)
            self.dict_list.update({name:idx})
            if os.path.exists(self.filename):
                os.remove(self.filename)
            with open(self.filename,'w+') as f:
                f.write(json.dumps(self.dict_list))
            self.dict_list = self._load_file()
        else:
            self.dict_list = self._load_file()
    
    
    def get_list(self):
        return self.dict_list
        
    def get_id(self,name):
        if name in self.dict_list.keys():
            return self.dict_list[name]
        else: 
            return -1
    

class FaceSearching():
    def __init__(self,numpy_path='recog_files/data/face_cache.npz',xml_path='recog_files/data/person_list.xml'):
        self.numpy_path = numpy_path
        self.features_list = np.load(self.numpy_path)['features_list']
        self.idx_list = np.load(self.numpy_path)['idx_list']
        self.person_dict = json.load(open(xml_path))
    
    def person_name(self,idx):
        return list(self.person_dict.keys())[list(self.person_dict.values()).index(idx)]
    
    def cosine_distance(self,a,b):
        return dot(a, b)/(norm(a)*norm(b))
    
    def linear_search(self,item):
        dis_high = 0
        idx_fi = 0
        for idx,itm in enumerate(self.features_list):
            calc_dis = self.cosine_distance(itm,item)
            if calc_dis >= dis_high:
                dis_high = calc_dis
                idx_fi = idx
        person_idx = self.idx_list[idx_fi]
        person = self.person_name(person_idx)
        return person_idx,person,dis_high
  
    
if __name__ == '__main__':
    # image = cv2.imread('img_cache/frame_390_.jpg')
    # feature_extractor = FaceFeatureExtract()
    # img_features = feature_extractor.make_face_features(image)
    # print('feature vector: ',img_features.shape)
    # print(img_features)
    person = PersonList()
    print(person.get_list())
    person.add_new('kamal_3')
    person.add_new('rex')
    print(person.get_list())
    print(person.get_id('alice'))
    print(person.get_id('bob'))
    print(person.get_id('john'))