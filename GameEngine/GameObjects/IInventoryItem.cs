using GameEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	/// <summary>
	/// An item to be used in battle of elsewhere in the game
	/// </summary>
	public interface IInventoryItem
	{
		/// <summary>
		/// Name of item
		/// </summary>
		string ItemName { get; set; }
		/// <summary>
		/// Short description about item effects
		/// </summary>
		string ItemDescription { get; set; }
		/// <summary>
		/// Price of item when selling or buying
		/// </summary>
		int ItemPrice { get; set; }
		/// <summary>
		/// List of functions that will be called when item is used
		/// </summary>
		List<Action> ItemEffects { get; set; }

	}
}
