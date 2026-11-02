using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace SongPaper
{
    public class SPSongFinder
    {
        private const float mins = 1.0f;
        private const float maxs = 1000.0f;
        private List<byte> dataBuffer = new List<byte>();
        public async Task<(Song foundSong, bool success)> FindSongAsync(float finds)
        {
            var result = (fs:new Song(), sc:false);
            
            if (finds < mins||finds>maxs) return result;

            var rb = new WasapiRecorderBuilder();
            rb.WithLoopbackCapture();

            using (var r = rb.Build())
            {
                r.DataAvailable += OnData;
                r.StartRecording();

                await Task.Delay((int)(1000f*finds));

                r.StopRecording();
            }
            
            



            //end
            result.sc = true;
            return result;
        }

        private void OnData(ReadOnlySpan<byte> buffer, AudioClientBufferFlags flags, long devicePosition, long qpcPosition)
        {
            foreach (var b in buffer) dataBuffer.Add(b);
        }

        

    }
}
