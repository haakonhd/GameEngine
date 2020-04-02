using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Tools
{
	public static class HelperMethods
	{
		public static double GetRandomNumber(double minimum, double maximum)
		{
			Random random = new Random();
			return random.NextDouble() * (maximum - minimum) + minimum;
		}
		
		public static void SetCellObjectCopyProps(ICellObject original, ICellObject copy)
		{
			copy.Sprite = original.Sprite;
			copy.IsPassable = original.IsPassable;
			copy.Position = original.Position;
			copy.EventTriggers = original.EventTriggers;
			copy.CellWidth = original.CellWidth;
			copy.CellHeight = original.CellHeight;
		}
	}
}
