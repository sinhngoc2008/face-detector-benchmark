using OpenCvSharp;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XIsom.BigWatcher.Facefetection
{
    /// <summary>
    /// Single Image Processing object class for saving data into the Datagridview
    /// </summary>
    [XmlRoot(ElementName = "ProcessedRowData")]
    public class ProcessedRowData
    {
        /// <summary>
        /// Row Id of the image
        /// </summary>
        [XmlElement(ElementName = "RowID")]
        public int RowID;
        /// <summary>
        /// filename
        /// </summary>
        [XmlElement(ElementName = "FileName")]
        public string FileName;
        /// <summary>
        /// Detected faces (number) 
        /// </summary>
        [XmlElement(ElementName = "DetectFaceNumber")]
        public int DetectFaceNumber;
        /// <summary>
        /// Detected face Rectagles by the Facedetector class obj. 
        /// </summary>
        [XmlArray(ElementName = "Faces")]
        public Rect[] Faces;

        /// <summary>
        /// Main constructor for the class
        /// </summary>
        /// <param name="rowID"></param>
        /// <param name="fileName"></param>
        /// <param name="faces"></param>
        public ProcessedRowData(int rowID,string fileName,Rect[] faces)
        {
            this.RowID = rowID;
            this.FileName = fileName;
            this.Faces = faces;
            this.DetectFaceNumber = faces.Length;
        }

        /// <summary>
        /// Empty constructor for the class (need for the XML serialization)
        /// </summary>
        public ProcessedRowData()
        {
            this.RowID = 0;
            this.FileName = string.Empty;
            this.Faces = null;
            this.DetectFaceNumber = 0;
        }

        /// <summary>
        /// makes a serilized xml of all the detected faces from the Rectangles array
        /// </summary>
        /// <returns> string of the generated XML </returns>
        public string getSerializeRectforXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.Faces.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, this.Faces);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }
        /// <summary>
        /// makes Rectangles array from the given XML obj. Reverse of the getSerializeRectforXML()
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Rectangles array from the XML </returns>
        public Rect[] setRectFromXML(string data)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Rect[]));
            return (Rect[]) reader.Deserialize(new StringReader(data));
        }

    }
}
