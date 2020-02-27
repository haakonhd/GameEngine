using GameEngineRuntimeComponent.Events;
using GameEngineRuntimeComponent.Factories;
using System.Collections.Generic;

namespace GameEngine.GameObjects
{
	class Npc : ICellObject
	{
		public int HealthPoints { get; set; }
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public string Key { get; set; }
		public List<IGameEvent> EventTriggers { get; set; }
        public (int x, int y) Position { get; set; }

		public Npc()
		{
			Sprite = new Sprite("npc.png");
			IsPassable = false;
			HealthPoints = 20;
			Key = "NPC";
			EventTriggers = new List<IGameEvent>();
			EventTriggers.Add(GameEventFactory.Build("SPEAK"));
		}
	}
}
