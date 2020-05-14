using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameBoard
{
	public interface IAreaSingleton
	{
		void resetArea();
		Area Area { get; set; }
	}
}
