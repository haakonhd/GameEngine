using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine.Implementation.Pokemon.Factories
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
					return null; //TODO: handle error, should have parameter
				default:
					return null;
			}
		}

		public static IGameEvent Build(EventName eventName, IFighter enemy)
		{
			//TODO: handle error
			if (eventName != EventName.StartBattle) return null;
			//TODO: Finish this
			return null;
		}
	}
}
