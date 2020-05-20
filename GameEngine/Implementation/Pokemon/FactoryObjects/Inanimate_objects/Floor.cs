using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Floor : ICellObject
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public (int x, int y) Position { get; set; }
		public List<GameEvent> EventTriggers { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }

		public Floor()
		{
			SetSprite();
			IsPassable = true;
			EventTriggers = null;
			CellWidth = 1;
			CellHeight = 1;
		}

		public void SetSprite()
		{
			this.Sprite = new Sprite("floor.png");
		}
	}
}
