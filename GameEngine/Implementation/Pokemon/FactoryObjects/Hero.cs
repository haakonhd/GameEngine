﻿using GameEngine.Factories;
using GameEngine.Implementation.Pokemon.Factories;
using GameEngineRuntimeComponent.Events;
using GameEngineRuntimeComponent.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.Factories.CellObjectFactory;
using static GameEngine.Implementation.Pokemon.Factories.BattleAttackFactory;
using static GameEngine.Implementation.Pokemon.Factories.InventoryItemFactory;

namespace GameEngine.GameObjects
{
	class Hero : IPlayableCharacter
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public int HealthPoints { get; set; }
		public int Level { get; set; }
		public List<IGameEvent> EventTriggers { get; set; }
        public (int x, int y) Position { get; set; }
		public List<IInventoryItem> ItemInventory { get; set; } = new List<IInventoryItem>();
		public List<IBattleAttack> BattleAttacks { get; set; } = new List<IBattleAttack>();
		public CellObjectType EnumType { get; set; }

		public Hero()
		{
			Sprite = new Sprite("hero.png");
			IsPassable = true;
			EnumType = CellObjectType.Hero;
			HealthPoints = 20;
			Level = 5;
			EventTriggers = null;
			ItemInventory.Add(InventoryItemFactory.Build(ItemName.SmallHealthPotion));
			BattleAttacks.Add(BattleAttackFactory.Build(AttackName.Stab));
		}
	}
}
