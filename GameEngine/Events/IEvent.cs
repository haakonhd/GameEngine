using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineRuntimeComponent.Events
{
	public interface IEvent
	{
		Action Event { get; set; }
	}
}
