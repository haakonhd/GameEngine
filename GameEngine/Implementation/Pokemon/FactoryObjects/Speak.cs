using GameEngineRuntimeComponent.Events;
using System;
using System.Diagnostics;
using GameEngine.GameBoard;

namespace GameEngineRuntimeComponent.FactoryObjects
{
	class Speak : IGameEvent
	{
		public string SpeechLine { get; set; }
		public Action GameEvent { get; set; }

		//public string SpeechLine { get; set; }
		public Speak(string speechLine)
		{
			SpeechLine = speechLine;
			GameEvent = DoSpeak;
		}

		private void DoSpeak()
		{
			// use the SpeechLine prop here to customize voiceline
            
        }
    }
}
