using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Game
    {
        internal MediaHandler CurrentlyPlayingMusic { get; set; }
        public string GameName { get; set; }
        public List<Area> Areas{ get; }
		public Area StartArea { get; set; }

        public Game()
        {
            Areas = new List<Area>();
        }
	}
}