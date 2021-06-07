using OpenCvSharp;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XIsom.BigWatcher.Facefetection
{
    [XmlRoot(ElementName = "ProcessedRowData")]
    public class ProcessedRowData
    {
        FaceDetector faceDetector;
        [XmlElement(ElementName = "rowID")]
        public int rowID;
        [XmlElement(ElementName = "fileName")]
        public string fileName;
        [XmlElement(ElementName = "detectFaceNumber")]
        public int detectFaceNumber;
        [XmlArray(ElementName = "faces")]
        public Rect[] faces;

        public ProcessedRowData(int rowID,string fileName)
        {
            this.rowID = rowID;
            this.fileName = fileName;
            this.faceDetector = new FaceDetector();
            this.faces = faceDetector.getDetectedFaces(fileName);
            this.detectFaceNumber = faceDetector.getNumberOfDetectedFaces(fileName);
        }

        public Image getImage()
        {
            return (Image) this.faceDetector.getFaceDetectedBitmapImage(this.fileName);
        }

    }
}
