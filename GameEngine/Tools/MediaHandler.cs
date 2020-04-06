using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace GameEngine
{
    public class MediaHandler : IDisposable
    {
        public MediaPlayer SoundPlayer;
        
        public MediaHandler(string fileName)
        {
            SoundPlayer = new MediaPlayer();
            //string musicPath = "ms-appx:///Assets/" + fileName;
            string musicPath = "ms-appx:///Implementation/" + Game.Instance.GamePathName + "/Assets/" + fileName;
            SoundPlayer.Source = MediaSource.CreateFromUri(new Uri(musicPath));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                SoundPlayer.Dispose();

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }

}