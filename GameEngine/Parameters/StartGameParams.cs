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
		public int BoardWidth { get; set; }
		public int BoardHeight { get; set; }

		public StartGameParams(Area palletTown, int boardWidth, int boardHeight)
		{
			this.Area = palletTown;
			this.BoardWidth = boardWidth;
			this.BoardHeight = boardHeight;
		}

	}
}
