using GameEngine.GameObjects;
using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	public class HealthPotionSmall : IInventoryItem
	{
		public string ItemName { get; set; }
		public string ItemDescription { get; set; }
		public List<IGameEvent> ItemEffects { get; set; }
	}
}
