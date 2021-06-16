using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XIsom.BigWatcher.Facefetection
{
    /// <summary>
    /// Class for saving the state of program's important variables.
    /// 
    /// </summary>
    [XmlRoot(ElementName = "SaveData")]
    public class SaveData
    {   /// <summary>
        /// dir boolean value 
        /// </summary>
        [XmlElement(ElementName = "HasDir")]
        public bool HasDir;
        /// <summary>
        /// Dir. URL
        /// </summary>
        [XmlElement(ElementName = "DirString")]
        public string DirString;
        /// <summary>
        /// Img number at the state of saving
        /// </summary>
        [XmlElement(ElementName = "CurrentRowID")]
        public int CurrentRowID;
        /// <summary>
        /// Dataset for the DataGridView
        /// </summary>
        [XmlElement(ElementName = "MainDataSet")]
        public DataSet MainDataSet;

        /// <summary>
        /// main constructor for making the sve data obj
        /// </summary>
        /// <param name="hasDir"></param>
        /// <param name="dirString"></param>
        /// <param name="currentRowID"></param>
        /// <param name="mainDataSet"></param>
        public SaveData(bool hasDir, string dirString, int currentRowID, DataSet mainDataSet)
        {
            this.HasDir = hasDir;
            this.DirString = dirString;
            this.CurrentRowID = currentRowID;
            this.MainDataSet = mainDataSet;
        }

        /// <summary>
        /// Used for the XML Serilaization
        /// </summary>
        public SaveData()
        {
            this.HasDir = false;
            this.DirString = string.Empty;
            this.CurrentRowID = 0;
            this.MainDataSet = null;
        }
        /// <summary>
        /// function to make this whole class obj to a serialized XML string
        /// </summary>
        /// <returns> the object as string.</returns>
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
