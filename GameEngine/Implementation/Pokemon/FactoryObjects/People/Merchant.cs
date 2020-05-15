using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects.People
{
	class Merchant : IMerchant
	{
		public List<IInventoryItem> ItemInventory { get; set; } = new List<IInventoryItem>();
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public List<GameEvent> EventTriggers { get; set; } = new List<GameEvent>();
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }

		public Merchant()
		{
			Sprite = new Sprite("merch");
			IsPassable = false;
			EventTriggers.Add(new GameEvent(1, startTrade, GameEvent.EventTypes.Interaction));
			ItemInventory.Add(InventoryItemFactory.Build(InventoryItemFactory.ItemName.SmallHealthPotion));
			CellWidth = 1;
			CellHeight = 1;
		}

		//TODO: create trading logic
		private void startTrade(){}

		public void SetSprite()
		{
			Sprite = new Sprite("merch.png");
		}
	}
}
