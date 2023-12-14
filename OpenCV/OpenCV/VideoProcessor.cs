using OpenCvSharp;
using System;
using System.IO;

namespace OpenCV
{
    public class VideoProcessor
    {
        private readonly string videoPath;
        private readonly string outputFolder;
        private readonly string cascadeClassifierPath;
        private readonly int duration;
        private readonly int distanceThreshold;
        private readonly FaceRecognizer faceRecognizer;
        public int CountImagesInOutputFolder(string outputFolder)
        {
            // Lógica para contar imágenes en la carpeta de salida
            var imageFiles = Directory.GetFiles(outputFolder, "*.png");
            return imageFiles.Length;
        }
        public VideoProcessor(string videoPath, string outputFolder, string cascadeClassifierPath, int duration, int distanceThreshold)
        {
            this.videoPath = videoPath;
            this.outputFolder = outputFolder;
            this.cascadeClassifierPath = cascadeClassifierPath;
            this.duration = duration;
            this.distanceThreshold = distanceThreshold;
            this.faceRecognizer = new FaceRecognizer(cascadeClassifierPath, distanceThreshold);
        }

        public void ProcessVideo()
        {
            var reader = new VideoCapture(videoPath);
            var fps = reader.Fps;
            var framesToCapture = (int)(fps * duration);

            Console.WriteLine("Procesando video. Esto puede llevar un tiempo...");

            for (var i = 0; i < framesToCapture && reader.IsOpened(); i++)
            {
                var image = reader.RetrieveMat();
                if (image.Empty())
                    break;

                faceRecognizer.DetectAndSaveFaces(image, i, outputFolder);

                
                Console.Write($"\rFotos procesadas: {i + 1}/{framesToCapture}");
            }

            Console.WriteLine(); 
        }
    }
}
