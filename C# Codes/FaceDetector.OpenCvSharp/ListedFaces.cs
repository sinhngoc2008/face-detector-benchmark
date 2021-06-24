using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using OpenCvSharp;
using System.Xml;

namespace FaceDetector.OpenCvSharp
{
    /// <summary>
    /// face listing XML serilizer 
    /// </summary>
    [XmlRoot(ElementName = "ListedFaces")]
    public class ListedFaces
    {
        [XmlElement(ElementName = "fileName")]
        public string fileName { get; set; }
        [XmlArray("faces")]
        public List<Rect> faces { get; set; }

    public ListedFaces()
        {
            this.fileName = null;
            this.faces = null;
        }

        public ListedFaces(string filename, List<Rect> faces)
        {
            this.fileName = filename;
            this.faces = faces;
        }

        public static string SerializeObject(object obj)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, obj);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }
    }
}
