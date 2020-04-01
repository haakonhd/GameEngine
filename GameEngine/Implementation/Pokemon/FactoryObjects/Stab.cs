using GameEngine.GameObjects;
using GameEngine.Events;
using System.Collections.Generic;
using System;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class Stab : IBattleAttack
	{
		public string AttackName { get; set; }
		public int AttackDamage { get; set; }
		public List<Action> AttackEffects { get; set; }

		public Stab(string attackName, int attackDamage)
		{
			AttackName = attackName;
			AttackDamage = attackDamage;
		}
	}
}
