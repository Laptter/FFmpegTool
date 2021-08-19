

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

            f1.OnProgress = progress => { Console.WriteLine("process1:\t"+progress); };

            f1.OnComplete = () => { Console.WriteLine("Convert Complete"); };

            Task.Factory.StartNew(() =>
            {
                f1.Work();
            });



            outputPath = @"C:\Users\Administrator\Desktop\Upload\6.avi";
            arg = $"-i {inputPath} {outputPath} -stats_period 0.1 -y";
            FFmpeg f2 = new FFmpeg(arg);

            f2.OnProgress = progress => { Console.WriteLine("process2:\t" + progress); };

            f2.OnComplete = () => { Console.WriteLine("Convert Complete"); };

            Task.Factory.StartNew(() =>
            {
                f2.Work();
            });


            Console.ReadKey();
        }
       
    }
}
