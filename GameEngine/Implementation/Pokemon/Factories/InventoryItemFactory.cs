using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine.Implementation.Pokemon.Factories
{
	public static class InventoryItemFactory
	{
		public enum ItemName
		{
			SmallHealthPotion
		}
		public static IInventoryItem Build(ItemName itemName)
		{
			switch (itemName)
			{
				case ItemName.SmallHealthPotion :
					return new HealthPotionSmall();
				default:
					return null;
			}
		}
	}
}
