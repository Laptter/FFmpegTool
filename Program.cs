

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FFMpegSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = @"C:\Users\Administrator\Desktop\Upload\3.mp4";
            var outputPath = @"C:\Users\Administrator\Desktop\Upload\4.avi";
            var arg = $"-i {inputPath} {outputPath} -stats_period 0.1 -y";
            FFmpeg f1 = new FFmpeg(arg);
            f1.OnProgress = (o, p) => { Console.WriteLine("process1:\t" + p); };
            f1.OnComplete = (o, p) => { Console.WriteLine("Convert Complete"); };

            f1.Work(true);

            Console.ReadKey();
        }
       
    }
}
