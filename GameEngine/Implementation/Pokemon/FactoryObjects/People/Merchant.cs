using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects.People
{
	class Merchant : IMerchant
	{
		public List<IInventoryItem> ItemInventory { get; set; }
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public List<GameEvent> EventTriggers { get; set; }
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }

		public Merchant(List<IInventoryItem> itemInventory, Sprite sprite, bool isPassable, List<GameEvent> eventTriggers, (int x, int y) position, int cellWidth, int cellHeight)
		{
			ItemInventory = itemInventory ?? throw new ArgumentNullException(nameof(itemInventory));
			Sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
			IsPassable = isPassable;
			EventTriggers = eventTriggers ?? throw new ArgumentNullException(nameof(eventTriggers));
			Position = position;
			CellWidth = cellWidth;
			CellHeight = cellHeight;
		}

		public void SetSprite()
		{
			throw new NotImplementedException();
		}
	}
}
