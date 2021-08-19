using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMpegSharpTest
{
    public class FFmpeg
    {
        private Process process;
        public EventHandler<double> OnProgress;
        public EventHandler OnComplete;
        public EventHandler<string> OnError;
        private double totalTime;
        private string args;
        public FFmpeg(string args)
        {
            this.args = args;
        }


        /// <summary>
        /// 2个视频拼接
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outPut"></param>
        public void Concat(string input, string outPut)
        { 

        }

        /// <summary>
        /// 2个或者2个以上的视频拼接
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outPut"></param>
        public void Concat(string txtPath)
        {

        }


        /// <summary>
        /// 提取视频流
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outPut"></param>
        public void ExtractVideo(string input, string outPut)
        { 

        }

        /// <summary>
        /// 提取音频流
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outPut"></param>
        public void ExtractAudio(string input, string outPut)
        {

        }



        public void Work(bool mulThread)
        {
            if (mulThread)
            {
                Task.Factory.StartNew(() =>{
                    Work();
                });
            }
            else
            {
                Work();
            }
        }


        private void Work()
        {
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = FFmpegManager.Instancia.FFmpegPath,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true
            };
            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.Exited += Process_Exited;
            process.Start();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }



        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e.Data != null)
                {
                    string[] split = e.Data.Split(' ');
                    for (int i = 0; i < split.Length; i++)
                    {
                        if (split[i].StartsWith("time="))
                        {
                            var time = split[i].Split('=');
                            var s = TimeSpan.Parse(time[1]).TotalSeconds;
                            OnProgress?.Invoke(this,s/totalTime);
                        }
                        else if (split[i].Contains("Duration"))
                        {
                            var t = split[i + 1];
                            var time = t.Remove(t.Length - 1);
                            totalTime = TimeSpan.Parse(time).TotalSeconds;
                        }
                    }
                }
            }
            catch { }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            OnComplete?.Invoke(this,e);
        }
    }
}
