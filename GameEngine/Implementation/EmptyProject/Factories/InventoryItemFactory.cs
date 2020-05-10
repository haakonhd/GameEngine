using GameEngine.GameObjects;
using GameEngine.Implementation.EmptyProject.FactoryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.Factories
{
	class InventoryItemFactory
	{
		public enum ItemName
		{
			SmallHealthPotion
		}
		public static IInventoryItem Build(ItemName itemName)
		{
			switch (itemName)
			{
				case ItemName.SmallHealthPotion:
					return new HealthPotionSmall();
				default:
					return null;
			}
		}
	}
}
