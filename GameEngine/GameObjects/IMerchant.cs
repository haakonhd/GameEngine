using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	interface IMerchant
	{
		List<IInventoryItem> ItemInventory { get; set; }
	}
}
