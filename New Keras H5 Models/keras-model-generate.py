# basic import (here only tenforflow in needed)

import tensorflow as tf

# declearing the first model
first_model = tf.keras.Sequential()

# adding the only Conv2D layer
first_model.add(tf.keras.layers.Conv2D(32,3,padding='valid',activation="relu",input_shape=(32,32,3)))

# checking summary
first_model.summary()

# saving model h5
tf.keras.models.save_model(first_model,"first_model.h5")
# saving model pb
tf.saved_model.save(first_model,"first_model")


# declearing the second model
first_model = tf.keras.Sequential()

# adding the Conv2D and MaxPool2D layer
first_model.add(tf.keras.layers.Conv2D(32,3,padding='valid',activation="relu",input_shape=(32,32,3)))
first_model.add(tf.keras.layers.MaxPool2D((2,2),padding='valid'))

# checking summary
first_model.summary()

# saving model h5
tf.keras.models.save_model(first_model,"second_model.h5")
# saving model pb
tf.saved_model.save(first_model,"second_model")

# declearing the third model
first_model = tf.keras.Sequential()

# adding the Conv2D and MaxPool2D layer
first_model.add(tf.keras.layers.Conv2D(32,3,padding='valid',activation="relu",input_shape=(32,32,3)))
first_model.add(tf.keras.layers.MaxPool2D((2,2),padding='valid'))
first_model.add(tf.keras.layers.Flatten())
first_model.add(tf.keras.layers.Dense(10,activation='relu'))

# checking summary
first_model.summary()

# saving model h5
tf.keras.models.save_model(first_model,"third_model.h5")
# saving model pb
tf.saved_model.save(first_model,"third_model")

### checking if the saved lodel can be loaded. ###

print("first model loading")
first_model = tf.keras.models.load_model('first_model.h5')
first_model.summary()

print("second model loading")
first_model = tf.keras.models.load_model('second_model.h5')
first_model.summary()

print("third model loading")
first_model = tf.keras.models.load_model('third_model.h5')
first_model.summary()