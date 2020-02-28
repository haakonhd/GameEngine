using GameEngine.Factories;
using GameEngineRuntimeComponent.Events;
using GameEngineRuntimeComponent.Factories;
using System.Collections.Generic;
using static GameEngine.Factories.CellObjectFactory;
using static GameEngineRuntimeComponent.Factories.GameEventFactory;

namespace GameEngine.GameObjects
{
	class Npc : ICellObject
	{
		public int HealthPoints { get; set; }
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public List<IGameEvent> EventTriggers { get; set; }
        public (int x, int y) Position { get; set; }
		public CellObjectType EnumType { get; set; }

		public Npc()
		{
			Sprite = new Sprite("npc.png");
			IsPassable = false;
			HealthPoints = 20;
			EnumType = CellObjectType.Npc;
			EventTriggers = new List<IGameEvent>();
			EventTriggers.Add(GameEventFactory.Build(EventName.SpeakHello));
		}
	}
}
