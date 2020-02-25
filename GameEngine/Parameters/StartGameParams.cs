using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Parameters
{
	public class StartGameParams
	{
		public Area Area { get; set; }
		public Game Game { get; set; }

		public StartGameParams(Area startArea, Game game)
		{
			Area = startArea;
			Game = game;
		}

	}
}
