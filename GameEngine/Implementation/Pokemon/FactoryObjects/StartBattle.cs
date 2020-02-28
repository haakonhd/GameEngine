using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class StartBattle : IGameEvent
	{
		public Action GameEvent { get; set; }
		public IFighter Hero { get; set; }
		public IFighter Enemy { get; set; }

		public StartBattle(IFighter hero, IFighter enemy)
		{
			Hero = hero;
			Enemy = enemy;
			GameEvent = DoStartBattle;
		}

		private void DoStartBattle()
		{
			new Battle(Hero, Enemy);
		}
	}
}
