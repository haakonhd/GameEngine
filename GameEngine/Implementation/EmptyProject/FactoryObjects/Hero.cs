using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.Implementation.EmptyProject.Factories.BattleAttackFactory;
using static GameEngine.Implementation.EmptyProject.Factories.CellObjectFactory;
using static GameEngine.Implementation.EmptyProject.Factories.InventoryItemFactory;

namespace GameEngine.Implementation.EmptyProject.Factories
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
		public List<GameEvent> EventTriggers { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
		public Sprite BattleSprite { get; set; }

		public Hero()
		{
			Sprite = new Sprite("hero.png");
			BattleSprite = new Sprite("hero.png");
			IsPassable = true;
			EnumType = CellObjectType.Hero;
			HealthPoints = 20;
			Level = 5;
			EventTriggers = null;
			ItemInventory.Add(InventoryItemFactory.Build(ItemName.SmallHealthPotion));
			BattleAttacks.Add(BattleAttackFactory.Build(AttackName.Stab));
			PlayerMoney = 0;
			CellWidth = 1;
			CellHeight = 1;
		}

		public void SetSprite()
		{
			this.Sprite = new Sprite("hero.png");
		}
	}
}
