using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	public class PlayableCharacter
	{
		public ICellObject CellObject { get; set; }
		public PlayableCharacter(ICellObject cellObject)
		{
			CellObject = cellObject;
		}

	}
}
