using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using System;
using System.Collections.Generic;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Npc : ICellObject
	{
		public int HealthPoints { get; set; }
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
        public (int x, int y) Position { get; set; }
		public CellObjectType EnumType { get; set; }
		public List<GameEvent> EventTriggers { get; set; } = new List<GameEvent>();

		public Npc()
		{
			Sprite = new Sprite("npc.png");
			IsPassable = false;
			HealthPoints = 20;
			EnumType = CellObjectType.Npc;
			//EventTriggers.Add(1, new MediaHandler("bump.mp3").SoundPlayer.Play);
			EventTriggers.Add(new GameEvent(1, new MediaHandler("bump.mp3").SoundPlayer.Play, GameEvent.EventTypes.Collision));
		}

		public ICellObject GetCopy()
		{
			throw new System.NotImplementedException();
		}
	}
}
