using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	class Grass : CellObject
	{
		public Grass()
		{
			Sprite = new Sprite("grass.png");
			IsPassable = true;
		}
	}
}
