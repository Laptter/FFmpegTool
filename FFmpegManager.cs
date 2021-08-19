using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMpegSharpTest
{
    public class FFmpegManager : Singleton<FFmpegManager>
    {
        public string FFmpegPath
        {
            get
            {
                return @"E:\Jxl_WorkSpace\ffmpeg\bin\x64\ffmpeg.exe";
            }
        }
    }
}
