using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.FactoryObjects
{
	class HealthPotionSmall : IInventoryItem
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
