using GameEngine;
using GameEngine.Implementation.Pokemon.FactoryObjects;
using GameEngineRuntimeComponent.Events;
using GameEngineRuntimeComponent.FactoryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineRuntimeComponent.Factories
{
	public static class GameEventFactory
	{
		public enum EventName
		{
			SpeakHello,
			SpeakGoodbye,
			StartBattle
		}
		public static IGameEvent Build(EventName eventName)
		{
			switch (eventName)
			{
				case EventName.SpeakHello:
					return new Speak("Hello");
				case EventName.SpeakGoodbye:
					return new Speak("Good bye");
				case EventName.StartBattle:
					//oops
					//TODO: StartBattle is hungry for arguments. We need to change something here
					return new StartBattle(null,null);
				default:
					return null;
			}
		}
	}
}
