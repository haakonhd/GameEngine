using GameEngine.Events;
using GameEngine.GameObjects;
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

		public StartBattle()
		{
			GameEvent = DoStartBattle;
		}

		private void DoStartBattle()
		{
			//new Battle();
		}
	}
}
