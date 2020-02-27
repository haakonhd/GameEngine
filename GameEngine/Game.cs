using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Game
    {
        internal MediaHandler CurrentlyPlayingMusic { get; set; }
        public string Title { get; set; }
        public List<Area> Areas{ get; }
		public Area CurrentArea { get; set; }
        public int GameWidth { get; set; }
        public PlayableCharacter PlayableCharacter { get; set; }
        public Stopwatch stopWatch { get; }

        public Game()
        {
            Areas = new List<Area>();
            stopWatch = new Stopwatch();
        }
	}
}