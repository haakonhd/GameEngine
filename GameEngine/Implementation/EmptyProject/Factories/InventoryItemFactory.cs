using GameEngine.GameObjects;
using GameEngine.Implementation.EmptyProject.FactoryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.Factories
{
	/// <summary>
	/// Gives access to all the game's inventory items
	/// </summary>
	class InventoryItemFactory
	{
		public enum ItemName
		{
			SmallHealthPotion
		}
		/// <summary>
		/// Retrieves an instance of inventory item from selected enum
		/// </summary>
		/// <param name="itemName"></param>
		/// <returns></returns>
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
