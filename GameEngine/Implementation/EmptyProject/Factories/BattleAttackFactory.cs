using GameEngine.GameObjects;
using GameEngine.Implementation.EmptyProject.FactoryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.Factories
{
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
