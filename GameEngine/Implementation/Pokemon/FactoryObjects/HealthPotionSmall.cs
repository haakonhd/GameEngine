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
		public List<Action> ItemEffects { get; set; } = new List<Action>();
		public int ItemPrice { get; set; }

		public HealthPotionSmall()
		{
			ItemEffects.Add(GiveHealth);
		}

		public void GiveHealth()
		{
			Battle.Instance.Hero.HealthPoints += 5;
		}
	}
}
