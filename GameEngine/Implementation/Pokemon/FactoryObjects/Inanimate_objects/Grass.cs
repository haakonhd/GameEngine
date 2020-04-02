using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngine.Tools;
using System;
using System.Collections.Generic;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Grass : ICellObject
	{
		public Sprite Sprite {get; set ; }
		public bool IsPassable { get; set; }
		public (int x, int y) Position { get; set ; }
		public CellObjectType EnumType { get; set; }
		public List<GameEvent> EventTriggers { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }

		public Grass()
		{
			this.Sprite = new Sprite("grass.png");
			IsPassable = true;
			EnumType = CellObjectType.Grass;
			EventTriggers = null;
			CellWidth = 1;
			CellHeight = 1;
		}

		public void SetSprite()
		{
			this.Sprite = new Sprite("grass.png");
		}
	}
}
