using GameEngine.Factories;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.Factories.CellObjectFactory;
using static GameEngine.Implementation.Pokemon.Factories.BattleAttackFactory;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Enemy : ICellObject, IFighter
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public CellObjectType EnumType { get; set; }
		public List<IGameEvent> EventTriggers { get; set; } = new List<IGameEvent>();
		public (int x, int y) Position { get; set; }
		public int HealthPoints { get; set; }
		public List<IInventoryItem> ItemInventory { get; set; } = new List<IInventoryItem>();
		public List<IBattleAttack> BattleAttacks { get; set; } = new List<IBattleAttack>();
		public int Level { get; set; }

		public Enemy()
		{
			Sprite = new Sprite("enemy.png");
			IsPassable = false;
			EnumType = CellObjectType.Enemy;
			HealthPoints = 10;
			Level = 2;
			BattleAttacks.Add(BattleAttackFactory.Build(AttackName.Stab));
		}
	}
}
