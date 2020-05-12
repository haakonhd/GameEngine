using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	/// <summary>
	/// Entity that can sell items
	/// </summary>
	interface IMerchant
	{
		/// <summary>
		/// List of items available to sell
		/// </summary>
		List<IInventoryItem> ItemInventory { get; set; }
	}
}
