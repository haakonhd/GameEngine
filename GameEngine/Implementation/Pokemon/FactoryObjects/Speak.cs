using GameEngineRuntimeComponent.Events;
using System;
using System.Diagnostics;
using GameEngine.GameBoard;

namespace GameEngineRuntimeComponent.FactoryObjects
{
	class Speak : IGameEvent
	{
		public Action GameEvent { get; set; }
		//public string SpeechLine { get; set; }
		public Speak()
		{
			GameEvent = DoSpeak;
		}

		private void DoSpeak()
		{
            //Debugger.Break();
			//ICellEntity temp = 
        }
    }
}
