using GameEngine.GameObjects;
using GameEngine.Implementation.EmptyProject.FactoryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.Factories
{
	/// <summary>
	/// Gives access to all the battle attacks in the game
	/// </summary>
	class BattleAttackFactory
	{
		public enum AttackName
		{
			Stab
		}
		public static IBattleAttack Build(AttackName attackName)
		{
			switch (attackName)
			{
				case AttackName.Stab:
					return new Stab("Stab", 5);
				default:
					return null;
			}
		}
	}
}
