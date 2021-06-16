using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace XIsom.BigWatcher.Facefetection
{
    /// <summary>
    /// FaceDetector Class for the system 
    /// </summary>
    public class FaceDetector
    {
        /// <summary>
        /// Main CascadeClassifier
        /// </summary>
        private CascadeClassifier FaceClassifier;
        /// <summary>
        /// The HAAR XML file for the face detection
        /// </summary>
        private string HaarFileName;

        /// <summary>
        /// Main constructor
        /// </summary>
        public FaceDetector()
        {
            // getting the main HAAR XML
            this.HaarFileName = Directory.GetCurrentDirectory().ToString() + @"\..\..\..\Haar\haarcascade_frontalface_default.xml";
            this.FaceClassifier = new CascadeClassifier(this.HaarFileName);

        }
        /// <summary>
        /// Const. If we need dirrernt Haar file for other detection
        /// </summary>
        /// <param name="fileName"></param>
        public FaceDetector(string fileName)
        {
            this.HaarFileName = fileName;
            this.FaceClassifier = new CascadeClassifier(this.HaarFileName);
        }
        /// <summary>
        /// make Matrix obj of the color image from file
        /// </summary>
        /// <param name="imgFileName"></param>
        /// <returns>Matrix</returns>
        public Mat processedColorImage(string imgFileName)
        {
            return new Mat(imgFileName, ImreadModes.Color);
        }
        /// <summary>
        /// make Matrix obj of the grayscale image from file.
        /// as cascade detector need grayscale input.
        /// </summary>
        /// <param name="imgFileName"></param>
        /// <returns>Matrix</returns>
        public Mat processedGrayScaleImage(string imgFileName)
        {
            return new Mat(imgFileName, ImreadModes.Grayscale);
        }
        /// <summary>
        /// getting the detect faces as the rect object.
        /// </summary>
        /// <param name="imgFilename"></param>
        /// <returns></returns>
        public Rect[] getDetectedFaces(string imgFilename) 
        {
            Mat grayscaleImage = processedGrayScaleImage(imgFilename);
            return this.FaceClassifier.DetectMultiScale(grayscaleImage);
        }

        /// <summary>
        /// returns the image with face draen
        /// </summary>
        /// <param name="imgFilename"></param>
        /// <returns></returns>
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
        /// <summary>
        /// construct the detected face from the given images and Rectangle array for click display. 
        /// </summary>
        /// <param name="imageFilename">image filename </param>
        /// <param name="faces"> Rectangle array </param>
        /// <returns>Image to display in the picturebox</returns>
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
