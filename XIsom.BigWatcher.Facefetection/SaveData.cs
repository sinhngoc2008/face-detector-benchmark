using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XIsom.BigWatcher.Facefetection
{
    [XmlRoot(ElementName = "SaveData")]
    public class SaveData
    {
        [XmlElement(ElementName = "hasDir")]
        public bool hasDir;
        [XmlElement(ElementName = "dirString")]
        public string dirString;
        [XmlElement(ElementName = "currentRowID")]
        public int currentRowID;
        [XmlElement(ElementName = "mainDataSet")]
        public DataSet mainDataSet;

        public SaveData(bool hasDir, string dirString, int currentRowID, DataSet mainDataSet)
        {
            this.hasDir = hasDir;
            this.dirString = dirString;
            this.currentRowID = currentRowID;
            this.mainDataSet = mainDataSet;
        }


        public SaveData()
        {
            this.hasDir = false;
            this.dirString = string.Empty;
            this.currentRowID = 0;
            this.mainDataSet = null;
        }

        public string ReturnSavedXML()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                xmlDocument.Load(memoryStream);
                memoryStream.Close();
                return xmlDocument.InnerXml;
            }
           
        }
    }
}
