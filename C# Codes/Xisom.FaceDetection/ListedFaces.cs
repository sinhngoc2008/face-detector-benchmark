using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using OpenCvSharp;
using System.Xml;

namespace Xisom.FaceDetection
{
    
    public class ListedFaces
    {
        [XmlArray("faces")]
        public List<Rect> faces { get; set; }

    public ListedFaces()
        { 
            this.faces = null;
        }

        public ListedFaces(List<Rect> faces)
        {
            this.faces = faces;
        }

        public string SerializeObject()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms,this);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }
    }

   
}
