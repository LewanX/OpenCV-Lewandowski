using System;
using System.IO;

namespace OpenCV
{
    internal class Program
    {
        private const string VideoPath = "../../videos/video.mp4";
        private const string OutputFolder = "../../frames/output";

        private const string CascadeClassifierPath = "../../haarcascades/haarcascade_frontalface_default.xml";
        private const int Duration = 10;
        private const int DistanceThreshold = 100;

        static void Main(string[] args)
        {
            Directory.CreateDirectory(OutputFolder);

            var videoProcessor = new VideoProcessor(VideoPath, OutputFolder, CascadeClassifierPath, Duration, DistanceThreshold);
            videoProcessor.ProcessVideo();

            Console.WriteLine($"Procesamiento completado. Imágenes guardadas en {OutputFolder}.");
        }
    }
}
