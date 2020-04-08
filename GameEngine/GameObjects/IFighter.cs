using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	public interface IFighter
	{
		int HealthPoints { get; set; }
		Sprite BattleSprite { get; set; }
		List<IInventoryItem> ItemInventory { get; set; }
		List<IBattleAttack> BattleAttacks { get; set; }
		int Level { get; set; }
	}
}
