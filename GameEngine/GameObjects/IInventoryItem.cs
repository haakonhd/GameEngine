using GameEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	public interface IInventoryItem
	{
		string ItemName { get; set; }
		string ItemDescription { get; set; }
		int ItemPrice { get; set; }
		List<Action> ItemEffects { get; set; }
	}
}
