using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class TextView
	{
		public string Text { get; set; }
		public TextBox TextBox { get; set; }
		public int Width { get; set; }

		public TextView()
		{
			Width = Game.GetInstance().GameWidth;
		}
	}
}
