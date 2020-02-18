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
        private MediaPlayer _mediaPlayer;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
        public MediaHandler(string fileName)
        {
            _mediaPlayer = new MediaPlayer();
            string musicPath = "ms-appx:///Assets/" + fileName;
            _mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(musicPath));
        }

        public void PlayMusic()
        {
            _mediaPlayer.Play();
        }


        public void PauseMusic()
        {
            _mediaPlayer.Pause();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}