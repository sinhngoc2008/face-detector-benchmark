using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xisom.ReDesigned.FaceDetector
{
    /// <summary>
    ///Static CSV maker class form the dataset for C#
    /// need to export the dataset as CSV.
    /// 
    /// can be extended as other extentions as (TSV,excel) too
    /// </summary>
    public static class CSVUtility
    {
        /// <summary>
        /// CSV file maker static function
        /// </summary>
        /// <param name="dtDataTable"></param>
        /// <param name="strFilePath"></param>
        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter streamWriter = new StreamWriter(strFilePath, false);
            // Making the headers for CSV    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                streamWriter.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write(streamWriter.NewLine);
            foreach (DataRow dataRow in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dataRow[i]))
                    {
                        string value = dataRow[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            streamWriter.Write(value);
                        }
                        else
                        {
                            streamWriter.Write(dataRow[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        streamWriter.Write(",");
                    }
                }
                streamWriter.Write(streamWriter.NewLine);
            }
            streamWriter.Close();
        }
    }
}
