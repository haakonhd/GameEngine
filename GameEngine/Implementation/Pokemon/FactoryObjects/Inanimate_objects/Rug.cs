using GameEngine.Events;
using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects.Inanimate_objects
{
	class Rug : ICellObject
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
		public List<GameEvent> EventTriggers { get; set; } = new List<GameEvent>();

		public Rug()
		{
			SetSprite();
			IsPassable = true;
			CellWidth = 2;
			CellHeight = 1;
			EventTriggers = null;
		}


		public void SetSprite()
		{
			this.Sprite = new Sprite("rug_2x1.png");
		}
	}
}
