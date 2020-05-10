using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.FactoryObjects
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
