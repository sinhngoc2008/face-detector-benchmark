from __future__ import print_function,absolute_import,division
import numpy as np

import tensorflow as tf


import json
import os

from tensorflow.keras.models import load_model



class Model():
    def __init__(self,model_path=None,weight_path=None,json_file_path=None):
        self.PureNodes = []
        self.PureConnectors = []
        self.json_file_path = json_file_path
        if model_path is not None:
            self.model = load_model(model_path)
            self.model.compile(optimizer='adam', loss='categorical_crossentropy',metrics=['accuracy'])
        else:
            self.model = self._make_model()
            self.model.compile(optimizer='adam', loss='categorical_crossentropy',metrics=['accuracy'])
        
        if weight_path is not None:
            self.model.load_weights(weight_path)
    
    
    def show_model(self):
        return self.model.summary()
        
    def get_outputs(self):
        return [(layer.name,self.model.layers[i]) for i,layer in enumerate(self.model.layers)]
    
    def _make_model(self):
        model = tf.keras.Sequential(
        [
            tf.keras.Input(shape=(28,28,1)),
            tf.keras.layers.Conv2D(32, kernel_size=(3, 3), activation="relu"),
            tf.keras.layers.MaxPooling2D(pool_size=(2, 2)),
            tf.keras.layers.Flatten(),
            tf.keras.layers.Dense(10, activation="softmax"),
        ])
        return model
    
    def make_json_file(self,path='model_json.json'):
        if self.json_file_path is None:
            self.json_file_path = path
        data = self.make_json()
        with open(self.json_file_path,'w') as json_file:
            json.dump(data,json_file,indent=4)
    
    
    def get_layerwise_info(self):
        main_position_x = 2117.6
        main_position_y = 2094.4
        for i,layer in enumerate(self.model.layers):
            
            node = dict()
            
            if layer.name.split('_')[0] == 'conv2d':
                    conv_obj = self.model.layers[i]
                    #print(i,conv_obj)
                    node.update(dict({"LayerArgs": dict({
                                      "$type": "XisomNet.LayersArgs.LayerCNN2DArgs, XisomNet",
                                      "Filters": conv_obj.filters,
                                      "KernelSize": [conv_obj.kernel_size[0],conv_obj.kernel_size[0]],
                                      "Strides": conv_obj.strides[0],
                                      "Paddings": 1,
                                      "DilationRate": conv_obj.dilation_rate[0],
                                      "Activation": 0,
                                      "UseBias": 0,
                                      "KernelInitializer": 4,
                                      "BiasInitializer": 1,
                                      "KernelRegularizer": 0,
                                      "BiasRegularizer": 0,
                                      "ActivityRegularizer": 0,
                                      "KernelConstraint": 0,
                                      "BiasConstraint": 0
                                                   }),
                                     "OffSetPoint": "0, 0",
                                      "SeqID": i,
                                      "ID": 0,
                                      "LayerType": 1,
                                      "isDraggable": 'true',
                                      "isDragging": 'false',
                                      "NameLayer": "CNN2D",
                                      "X": main_position_x,
                                      "Y": main_position_y}))
            if layer.name.split('_')[0] == 'max':
                    #print(i,self.model.layers[i])
                    max_obj = self.model.layers[i]
                    node.update(dict({"LayerArgs": dict({
                                      "$type": "XisomNet.LayersArgs.LayerMaxPooling2DArgs, XisomNet",
                                      "PoolSize": [max_obj.pool_size[0],max_obj.pool_size[0]],
                                      "Strides": max_obj.strides[0],
                                      "Paddings": 1
                                                   }),
                                     "OffSetPoint": "0, 0",
                                      "SeqID": i,
                                      "ID": 1,
                                      "LayerType": 10,
                                      "isDraggable": 'true',
                                      "isDragging": 'false',
                                      "NameLayer": "MAXPOOLING2D",
                                      "X": main_position_x,
                                      "Y": main_position_y}))
            if layer.name.split('_')[0] == 'flatten':
                    #print(i,self.model.layers[i])
                    node.update(dict({"LayerArgs": dict({
                    "$type": "XisomNet.LayersArgs.LayerFlattenArgs, XisomNet"}),
                    "OffSetPoint": "0, 0",
                    "SeqID": i,
                    "ID": 3,
                    "LayerType": 15,
                    "isDraggable": 'true',
                    "isDragging": 'false',
                    "NameLayer": "FLATTEN",
                    "X": main_position_x,
                    "Y": main_position_y
                    }))
                    
            if layer.name.split('_')[0] == 'dense':
                    #print(i,self.model.layers[i])
                    fc_obj = self.model.layers[i]
                    node.update(dict({
                    "LayerArgs": dict({
                    "$type": "XisomNet.LayersArgs.LayerFCArgs, XisomNet",
                    "Units": fc_obj.units,
                    "Activation": 1,
                    "UseBias": 0,
                    "KernelInitializer": 4,
                    "BiasInitializer": 1,
                    "KernelRegularizer": 0,
                    "BiasRegularizer": 0,
                    "ActivityRegularizer": 0,
                    "KernelConstraint": 0,
                    "BiasConstraint": 0
                    }),
                    "OffSetPoint": "0, 0",
                    "SeqID": i,
                    "ID": 2,
                    "LayerType": 14,
                    "isDraggable": 'true',
                    "isDragging": 'false',
                    "NameLayer": "FC",
                    "X": main_position_x,
                    "Y": main_position_y}))
                    
            if layer.name.split('_')[0] == 'dropout':
                drop_obj = self.model.layers[i]
                node.update(dict({
                   "LayerArgs": dict({
                   "$type": "XisomNet.LayersArgs.LayerDropOutArgs, XisomNet",
                   "Rate": drop_obj.rate
                    }),
                   "OffSetPoint": "0, 0",
                   "SeqID": 3,
                   "ID": 1,
                   "LayerType": 12,
                   "isDraggable": true,
                   "isDragging": false,
                   "NameLayer": "DROPOUT",
                   "X": main_position_x,
                   "Y": main_position_y
                }
                ))
            self.PureNodes.append(node)
            main_position_y += 200
            
        for i in range(len(self.PureNodes)-1):
            self.PureConnectors.append(dict(
                {
                    "ID": 3,
                    "ParentNodeSeqID": i
                }
            ))
            self.PureConnectors.append(dict(
                {
                    "ID": 1,
                    "ParentNodeSeqID": i+1
                }
            ))
        return self.PureNodes,self.PureConnectors

    def make_json(self):
        p_n,p_c = self.get_layerwise_info()
        
        return dict({
            "PureNodes": p_n,
            "PureConnectors": p_c
        })

if __name__ == '__main__':
    model = Model()
    model.show_model()
    model.make_json_file(path='testing_2.json')
     
