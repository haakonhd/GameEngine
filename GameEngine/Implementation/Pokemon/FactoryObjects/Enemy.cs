using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using static GameEngine.Implementation.Pokemon.Factories.BattleAttackFactory;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Enemy : IEnemy
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public CellObjectType EnumType { get; set; }
		public (int x, int y) Position { get; set; }
		public int HealthPoints { get; set; }
		public List<IInventoryItem> ItemInventory { get; set; } = new List<IInventoryItem>();
		public List<IBattleAttack> BattleAttacks { get; set; } = new List<IBattleAttack>();
		public int Level { get; set; }
		public Dictionary<IInventoryItem, double> Loot { get; set; }
        public List<GameEvent> EventTriggers { get; set; } = new List<GameEvent>();

		public Enemy()
		{
			Sprite = new Sprite("enemy.png");
			IsPassable = false;
			EnumType = CellObjectType.Enemy;
			HealthPoints = 10;
			Level = 2;
			BattleAttacks.Add(Build(AttackName.Stab));
            EventTriggers.Add(new GameEvent(1, new MediaHandler("bump.mp3").SoundPlayer.Play, GameEvent.EventTypes.Collision));
			Loot = null;
		}

		public ICellObject GetCopy()
		{
			Enemy newEnemy = new Enemy();
			newEnemy = this;
			return newEnemy;
		}
	}
}
