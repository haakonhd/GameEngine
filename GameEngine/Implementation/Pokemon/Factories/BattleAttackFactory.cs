using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine.Implementation.Pokemon.Factories
{
	public static class BattleAttackFactory
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
