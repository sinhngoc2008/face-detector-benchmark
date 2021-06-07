using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Xisom.FaceDetection
{
    public class SaveStateData
    {
        
        [XmlElement(ElementName = "hasFolder")]
        public bool hasFolder;
        [XmlElement(ElementName = "folderDir")]
        public string folderDir;
        [XmlElement(ElementName = "dataset")]
        public DataSet dataset;
        [XmlElement(ElementName = "progressCount")]
        public int progressCount;

        public SaveStateData() 
        {
            this.hasFolder = false;
            this.folderDir = string.Empty;
            this.dataset = null;
            this.progressCount = 0;
        }

        public SaveStateData(bool hasFolder,string folderDir, DataSet dataSet,int progress)
        {
            this.hasFolder = hasFolder;
            this.folderDir = folderDir;
            this.dataset = dataSet;
            this.progressCount = progress;
        }

        public string SerializeObject()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, this);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }

    }
}
