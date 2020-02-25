using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineRuntimeComponent.FactoryObjects
{
	class Speak : IGameEvent
	{
		public Action GameEvent { get; set; }
		public string SpeechLine { get; set; }
		public Speak()
		{
			GameEvent = DoSpeak;
		}

		private void DoSpeak()
		{
			
			
		}

	}
}
