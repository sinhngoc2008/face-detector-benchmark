import sys
from PyQt5.QtWidgets import QApplication, QWidget, QFileDialog, QPushButton, QLineEdit, QInputDialog, QLabel
from PyQt5.QtGui import QIcon
from model_maker import Model
from tensorflow.keras.models import load_model
from model_maker import Model

class App(QWidget):

    def __init__(self):
        super().__init__()
        self.title = 'Xisom- Big Watcher Model Maker v-0.0.1'
        self.left = 10
        self.top = 10
        self.width = 640
        self.height = 480
        self.initUI()
    
    def showDialog(self):
        text, ok = QInputDialog.getText(self, 'Json File Save ', 'Enter File Name:')
        if ok:
            self.le.setText(str(text))
    
    def initUI(self):
        # Add button                                              
        self.btn = QPushButton('Show Input Dialog', self)
        self.btn.move(30, 20)
        text = self.btn.clicked.connect(self.showDialog)
        
        # Add label                                                    
        self.le = QLabel(self)
        self.le.move(30, 62)
        self.le.resize(400,22)
        
        self.setWindowTitle(self.title)
        self.setGeometry(self.left, self.top, self.width, self.height)
        
        file_ = self.openFileNameDialog()
        
        print(file_)
        
        model = load_model(file_)
        model.summary()
        new_model = Model(model_path=file_)
        new_model.show_model()
        print(text)
        new_model.make_json_file(path='testing_4.json')
        
        self.show()
    
    def openFileNameDialog(self):
        options = QFileDialog.Options()
        options |= QFileDialog.DontUseNativeDialog
        fileName, _ = QFileDialog.getOpenFileName(self,"Big Watcher Model Selctor", "","H5 files(*.h5)", options=options)
        if fileName:
            print(fileName)
        return fileName
    

if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = App()
    sys.exit(app.exec_())