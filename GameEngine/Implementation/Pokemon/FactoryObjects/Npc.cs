using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using System.Collections.Generic;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;
using static GameEngine.Implementation.Pokemon.Factories.GameEventFactory;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Npc : ICellObject
	{
		public int HealthPoints { get; set; }
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
        public (int x, int y) Position { get; set; }
		public CellObjectType EnumType { get; set; }
		public Dictionary<IGameEvent, double> EventTriggers { get; set; }

		public Npc()
		{
			Sprite = new Sprite("npc.png");
			IsPassable = false;
			HealthPoints = 20;
			EnumType = CellObjectType.Npc;
			//EventTriggers = new List<IGameEvent>();
			//EventTriggers.Add(Build(EventName.SpeakHello));
		}

		public ICellObject GetCopy()
		{
			throw new System.NotImplementedException();
		}
	}
}
