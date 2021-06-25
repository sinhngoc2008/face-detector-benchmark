using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xisom.ReDesigned.FaceDetector
{
    public static class CSVUtility
    {
        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter streamWriter = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                streamWriter.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write(streamWriter.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            streamWriter.Write(value);
                        }
                        else
                        {
                            streamWriter.Write(dr[i].ToString());
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
