using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xisom.FaceDetection
{
    class Result
    {
        private int id;
        private Rect[] faces;
        private string fileName;

        public Result(int id, Rect[] faces, string fileName)
        {
            this.id = id;
            this.faces = faces;
            this.fileName = fileName;
        }
    }
}
