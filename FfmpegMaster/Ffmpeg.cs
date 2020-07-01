namespace FfmpegMaster
{
    public static class Ffmpeg
    {

        public static System.Diagnostics.Process Run(string Comand)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = ".\\ffmpeg.exe";
            startInfo.Arguments = Comand;
            process.StartInfo = startInfo;
        
            process.Start();
            process.WaitForExit();
            return process;
        }
    }
}
