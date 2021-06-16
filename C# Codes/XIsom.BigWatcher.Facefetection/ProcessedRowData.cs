using OpenCvSharp;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XIsom.BigWatcher.Facefetection
{
    [XmlRoot(ElementName = "ProcessedRowData")]
    public class ProcessedRowData
    {
        [XmlElement(ElementName = "rowID")]
        public int rowID;
        [XmlElement(ElementName = "fileName")]
        public string fileName;
        [XmlElement(ElementName = "detectFaceNumber")]
        public int detectFaceNumber;
        [XmlArray(ElementName = "faces")]
        public Rect[] faces;

        public ProcessedRowData(int rowID,string fileName,Rect[] faces)
        {
            this.rowID = rowID;
            this.fileName = fileName;
            this.faces = faces;
            this.detectFaceNumber = faces.Length;
        }

        public ProcessedRowData()
        {
            this.rowID = 0;
            this.fileName = string.Empty;
            this.faces = null;
            this.detectFaceNumber = 0;
        }

        public string getSerializeRectforXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.faces.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, this.faces);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }

        public Rect[] setRectFromXML(string data)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Rect[]));
            return (Rect[]) reader.Deserialize(new StringReader(data));
        }

    }
}
