using GameEngine.Events;
using GameEngine.GameObjects;
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
		public Dictionary<IGameEvent, double> EventTriggers { get; set; }

		public Grass()
		{
			Sprite = new Sprite("grass.png");
			IsPassable = true;
			EnumType = CellObjectType.Grass;
			EventTriggers = null;
		}

		//TODO: make this better, and create background-cellobject interface
		public ICellObject GetCopy()
		{
			Grass newGrass = new Grass();
			newGrass.Sprite = new Sprite("grass.png");
			newGrass.IsPassable = true;
			newGrass.EnumType = CellObjectType.Grass;
			newGrass.EventTriggers = null;
			return newGrass;
		}
	}
}
