using GameEngine;
using GameEngineRuntimeComponent.Events;
using GameEngineRuntimeComponent.FactoryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineRuntimeComponent.Factories
{
	static class GameEventFactory
	{
		public static IGameEvent Build(string eventName)
		{
			switch (eventName)
			{
				case "SPEAK":
					return new Speak();
				default:
					return null;
			}
		}
	}
}
