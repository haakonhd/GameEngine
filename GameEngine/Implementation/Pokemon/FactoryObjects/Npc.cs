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
		public Dictionary<double, Action> EventTriggers { get; set; } = new Dictionary<double, Action>();

		public Npc()
		{
			Sprite = new Sprite("npc.png");
			IsPassable = false;
			HealthPoints = 20;
			EnumType = CellObjectType.Npc;
			EventTriggers.Add(1, new MediaHandler("bump.mp3").SoundPlayer.Play);
		}

		public ICellObject GetCopy()
		{
			throw new System.NotImplementedException();
		}
	}
}
