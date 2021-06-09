using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

namespace XIsom.BigWatcher.Facefetection
{
    public class FaceDetector
    {
        private CascadeClassifier faceClassifier;
        private string haarFileName;

        public FaceDetector()
        {
            this.haarFileName = @"C:\Users\user\Dataset\wider_face_yolo\benchmark\tester\C#\TraningProgramming\Xisom.FaceDetection\FaceDetector.OpenCvSharp\Resources\haarcascade_frontalface_default.xml";
            this.faceClassifier = new CascadeClassifier(this.haarFileName);

        }

        public FaceDetector(string fileName)
        {
            this.haarFileName = fileName;
            this.faceClassifier = new CascadeClassifier(this.haarFileName);
        }

        public Mat processedColorImage(string imgFileName)
        {
            return new Mat(imgFileName, ImreadModes.Color);
        }

        public Mat processedGrayScaleImage(string imgFileName)
        {
            return new Mat(imgFileName, ImreadModes.Grayscale);
        }

        public Rect[] getDetectedFaces(string imgFilename) 
        {
            Mat grayscaleImage = processedGrayScaleImage(imgFilename);
            return this.faceClassifier.DetectMultiScale(grayscaleImage);
        }

        public int getNumberOfDetectedFaces(string imgFilename)
        {
            return this.faceClassifier.DetectMultiScale(processedGrayScaleImage(imgFilename)).Length;
        }

        public Bitmap getFaceDetectedBitmapImage(string imgFilename)
        {
            Rect[] faces = getDetectedFaces(imgFilename);
            Mat image = processedColorImage(imgFilename);

            if (faces.Length > 0)
            {
                foreach (Rect f in faces) 
                {
                    Cv2.Rectangle(image,f, Scalar.White, 3);
                }
            }

            return BitmapConverter.ToBitmap(image);

        }
        public Image makeFaceDetectedImage(string imageFilename, Rect[] faces) {
            Mat resultedImage = new Mat(imageFilename, ImreadModes.Color);
            if (faces.Length > 0)
            {
                foreach (Rect f in faces)
                {
                    Cv2.Rectangle(resultedImage, f, Scalar.White, 3);
                }
            }
            return BitmapConverter.ToBitmap(resultedImage);
        }
    }
}
