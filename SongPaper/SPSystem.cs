using System;
using System.Collections.Generic;
using System.Text;

namespace SongPaper
{
    public class SPSystem
    {
        private bool isRunning = false;
        public async Task StartAsync(CancellationToken token)
        {
            if(isRunning) return;
            isRunning = true;

            SPSongFinder finder = new SPSongFinder();
            
            while (!token.IsCancellationRequested)
            {
                var songResult = await finder.FindSongAsync(10);
                if (!songResult.success) continue;


            }
        
        }
        

    }

}
