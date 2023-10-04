using System.IO;
using NAudio.Wave;

namespace AudioModule
{
    public class AudioTool
    {
        //    static void Main()
        //    {
        //        string pcmFilePath = "path/to/your/pcm/file.pcm";
        //        string wavFilePath = "path/to/output/wav/file.wav";
        //
        //        ConvertPCMToWAV(pcmFilePath, wavFilePath);
        //    }

        public static void ConvertPCMToWAV(string pcmFilePath, string wavFilePath)
        {
            try
            {
                using (var pcmReader = new RawSourceWaveStream(File.OpenRead(pcmFilePath), new WaveFormat(44100, 16, 1)))
                {
                    using (var wavWriter = new WaveFileWriter(wavFilePath, pcmReader.WaveFormat))
                    {
                        byte[] buffer = new byte[pcmReader.Length];
                        int bytesRead = pcmReader.Read(buffer, 0, buffer.Length);
                        wavWriter.Write(buffer, 0, bytesRead);
                    }
                }
                Console.WriteLine("Conversion successful. WAV file created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting PCM to WAV: " + ex.Message);
            }
        }
    }
}
