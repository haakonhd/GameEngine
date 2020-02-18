using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace GameEngine
{
    public class Music
    {
        private MediaPlayer _mediaPlayer;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
        public Music()
        {
            _mediaPlayer = new MediaPlayer
            {
                Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/shake.mp3"))
            };
        }

        public void PlayMusic()
        {
            _mediaPlayer.Play();
        }


        public void PauseMusic()
        {
            _mediaPlayer.Pause();
        }
    }
}