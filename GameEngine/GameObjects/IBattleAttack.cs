using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	public interface IBattleAttack
	{
		string AttackName { get; set; }
		int AttackDamage { get; set; }
		List<IGameEvent> AttackEffects { get; set; }
	}
}
