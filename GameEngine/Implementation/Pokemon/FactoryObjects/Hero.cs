using GameEngine.Implementation.Pokemon.Factories;
using GameEngine.Events;
using System.Collections.Generic;
using static GameEngine.Implementation.Pokemon.Factories.BattleAttackFactory;
using static GameEngine.Implementation.Pokemon.Factories.InventoryItemFactory;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;
using GameEngine.GameObjects;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Hero : IPlayableCharacter
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public int HealthPoints { get; set; }
		public int Level { get; set; }
        public (int x, int y) Position { get; set; }
		public List<IInventoryItem> ItemInventory { get; set; } = new List<IInventoryItem>();
		public List<IBattleAttack> BattleAttacks { get; set; } = new List<IBattleAttack>();
		public CellObjectType EnumType { get; set; }
		public int PlayerMoney { get; set; }
		public Dictionary<IGameEvent, double> EventTriggers { get; set; }

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
			PlayerMoney = 0;
		}

		public ICellObject GetCopy()
		{
			throw new System.NotImplementedException();
		}
	}
}
