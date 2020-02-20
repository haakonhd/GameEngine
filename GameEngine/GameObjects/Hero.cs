using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	class Hero : CellObject, IFighter
	{
		public int HealthPoints { get; set; }

		public Hero(Sprite sprite, int healthPoints)
		{
			Sprite = sprite;
			IsPassable = true;
			HealthPoints = healthPoints;
		}
	}
}
