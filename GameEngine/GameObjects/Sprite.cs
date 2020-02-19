using GameEngine.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameEngine.GameObjects
{
	public class Sprite
	{
		public Image SpriteImage { get; private set; }

		public Sprite()
		{
		}

		public Sprite(string fileName)
		{
			SetSpriteFromFileName(fileName);
		}

		public void SetSpriteFromFileName(string fileName)
		{
			SpriteImage = new SpriteHandler().GetImageFromFileName(fileName);
		}
	}
}
