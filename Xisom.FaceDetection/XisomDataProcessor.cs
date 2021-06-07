using System;
using System.Collections;
using System.IO;


namespace Xisom.FaceDetection
{
    class XisomDataProcessor
    {
        private string dirString;
        private string[] filelist;
        private int numFile;

        public XisomDataProcessor(string dirString)
        {
            this.dirString = dirString;
            this.filelist = Directory.GetFiles(dirString.ToString(), "*.jpg", SearchOption.AllDirectories);
            this.numFile = this.filelist.Length;
        }

    }
}
