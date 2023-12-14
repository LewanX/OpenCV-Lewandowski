using System;
using System.Collections.Generic;
using System.IO;
using OpenCvSharp;

namespace OpenCV
{
    public class FaceRecognizer
    {
        private readonly List<Rect> detectedFaces = new List<Rect>();
        private readonly string cascadeClassifierPath;
        private readonly int distanceThreshold;

        public FaceRecognizer(string cascadeClassifierPath, int distanceThreshold)
        {
            this.cascadeClassifierPath = cascadeClassifierPath;
            this.distanceThreshold = distanceThreshold;
        }

        public void DetectAndSaveFaces(Mat image, int frameIndex, string outputFolder)
        {
           
            var resizedImage = new Mat();
            Cv2.Resize(image, resizedImage, new Size(image.Width / 2, image.Height / 2)); 

            var gray = new Mat();
            Cv2.CvtColor(resizedImage, gray, ColorConversionCodes.BGR2GRAY);

            var faceCascade = new CascadeClassifier(cascadeClassifierPath);
            var faces = faceCascade.DetectMultiScale(gray, 1.1, 3, HaarDetectionTypes.ScaleImage, new Size(30, 30));

            if (faces.Length > 0)
            {
                var firstFace = faces[0];
                var personIndex = FindAssociatedPerson(firstFace);

                SaveFaceImage(resizedImage, firstFace, frameIndex, personIndex, outputFolder);
            }
        }

        private void SaveFaceImage(Mat image, Rect face, int frameIndex, int personIndex, string outputFolder)
        {
            var personFolder = $@"{outputFolder}\person_{personIndex}";
            Directory.CreateDirectory(personFolder);

            var frameImageFileName = $@"{personFolder}\image_{frameIndex}.png";
            var roi = new Rect(face.X, face.Y, face.Width, face.Height);
            var croppedImage = new Mat(image, roi);
            Cv2.ImWrite(frameImageFileName, croppedImage);

            if (personIndex == -1)
            {
                detectedFaces.Add(face);
            }
        }

        private int FindAssociatedPerson(Rect currentFace)
        {
            for (var i = 0; i < detectedFaces.Count; i++)
            {
                var distance = CalculateDistance(currentFace, detectedFaces[i]);
                if (distance < distanceThreshold)
                {
                    return i;
                }
            }

            return -1;
        }

        private double CalculateDistance(Rect rect1, Rect rect2)
        {
            var center1 = new Point(rect1.X + rect1.Width / 2, rect1.Y + rect1.Height / 2);
            var center2 = new Point(rect2.X + rect2.Width / 2, rect2.Y + rect2.Height / 2);

            return Math.Sqrt(Math.Pow(center1.X - center2.X, 2) + Math.Pow(center1.Y - center2.Y, 2));
        }
    }
}
