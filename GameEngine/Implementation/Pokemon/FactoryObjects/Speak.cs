using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineRuntimeComponent.FactoryObjects
{
	class Speak : IEvent
	{
		public Action Event { get; set; }
		public string SpeechLine { get; set; }
		public Speak()
		{
			Event = DoSpeak;
		}

		private void DoSpeak()
		{
			
			
		}

	}
}
