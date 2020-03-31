using GameEngine.GameObjects;
using GameEngine.Events;
using System.Collections.Generic;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	public class HealthPotionSmall : IInventoryItem
	{
		public string ItemName { get; set; }
		public string ItemDescription { get; set; }
		public List<IGameEvent> ItemEffects { get; set; }
	}
}
