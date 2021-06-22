### basic imports

import numpy as np
np.random.seed(20210617)

from tensorflow.keras.layers import Conv1D, MaxPool1D, Input, Dense, Flatten, concatenate
from tensorflow.keras.models import Model

import tensorflow as tf

import pandas as pd
import matplotlib.pylab as plt 
import datetime
import os

# importing dataset (XoR)
data = pd.read_csv('dataset/xor-data.csv',header=0)

# splitting features and labels
features, label = data.iloc[:, :-1], data.iloc[:, [-1]]

features = np.reshape(features.to_numpy(),(48,2,1))
label = np.reshape(label.to_numpy(),(48,))

# checking data
print("Shape of the datas (featurs)(labels) : ",features.shape,label.shape)


# making model. 

main_input = Input(shape=(2,1))

first_part = Conv1D(10,2,padding='same',activation='relu')(main_input)
first_part = Conv1D(5,1,padding='same',activation='relu')(first_part)

second_part = Conv1D(5,2,padding='same')(first_part)
second_part = MaxPool1D(1)(second_part)

third_part = Conv1D(5,2,padding='same',activation='relu')(first_part)
third_part = Conv1D(5,1,padding='same',activation='relu') (third_part)



merged_1 = concatenate([first_part,second_part],axis=0)
merged_2 = concatenate([merged_1,third_part],axis=0)

output = Flatten()(merged_2)
output = Dense(10,activation='relu')(output)
output = Dense(1,activation='linear')(output)

model = Model(inputs=main_input,outputs=output)

model.compile(loss='binary_crossentropy',
              optimizer='adam',
              metrics=['accuracy'])
              

model.summary()


# making model graph image

from tensorflow.keras.utils import plot_model
plot_model(model,to_file='facenet_keras.png',dpi=100)


# model training
history = model.fit(features, label, batch_size=1,shuffle = True, nb_epoch=50)

print(history.history.keys())

#  "Accuracy" plotting
plt.plot(history.history['acc'])
plt.title('Model accuracy')
plt.ylabel('Accuracy')
plt.xlabel('Epoch')
plt.grid(True)
plt.show()


# "Loss" plotting 
plt.plot(history.history['loss'])
plt.title('Model loss')
plt.ylabel('Loss')
plt.xlabel('Epoch')
plt.grid(True)
plt.show()


# saving model h5
tf.keras.models.save_model(model,"xor_model.h5")

# graph freezing with tensorflow

def freeze_session(session, keep_var_names=None, output_names=None, clear_devices=True):
    """
    Freezes the state of a session into a pruned computation graph.

    Creates a new computation graph where variable nodes are replaced by
    constants taking their current value in the session. The new graph will be
    pruned so subgraphs that are not necessary to compute the requested
    outputs are removed.
    @param session The TensorFlow session to be frozen.
    @param keep_var_names A list of variable names that should not be frozen,
                          or None to freeze all the variables in the graph.
    @param output_names Names of the relevant graph outputs.
    @param clear_devices Remove the device directives from the graph for better portability.
    @return The frozen graph definition.
    
    SOURCE: https://stackoverflow.com/questions/45466020/how-to-export-keras-h5-to-tensorflow-pb
    
    """
    graph = session.graph
    with graph.as_default():
        freeze_var_names = list(set(v.op.name for v in tf.global_variables()).difference(keep_var_names or []))
        output_names = output_names or []
        output_names += [v.op.name for v in tf.global_variables()]
        input_graph_def = graph.as_graph_def()
        if clear_devices:
            for node in input_graph_def.node:
                node.device = ""
        frozen_graph = tf.graph_util.convert_variables_to_constants(
            session, input_graph_def, output_names, freeze_var_names)
        return frozen_graph


from tensorflow.keras import backend as K
from tensorflow.python.tools import freeze_graph

frozen_graph = freeze_session(K.get_session(),                          output_names=[out.op.name for out in model.outputs])

tf.io.write_graph(freeze_graph, "frozen_graph_xor", "xor_model_revised.pb", as_text=False)

#K.set_learning_phase(0)
#save_dir = "xor_{:%Y-%m-%d_%H%M%S}".format(datetime.datetime.now())
#tf.saved_model.simple_save(K.get_session(),save_dir,inputs={"input": model.inputs[0]},outputs={"output": model.outputs[0]})

#freeze_graph.freeze_graph(None,None,None,None,model.outputs[0].op.name,None,None,os.path.join(save_dir,"xor_frozen_model.pb"),False,"",input_saved_model_dir=save_dir)