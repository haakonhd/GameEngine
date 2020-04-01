using GameEngine.GameObjects;
using GameEngine.Events;
using System.Collections.Generic;
using System;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	public class HealthPotionSmall : IInventoryItem
	{
		public string ItemName { get; set; }
		public string ItemDescription { get; set; }
		public List<Action> ItemEffects { get; set; }
		public int ItemPrice { get; set; }
	}
}
