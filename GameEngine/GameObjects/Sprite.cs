using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

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
			SpriteImage = GetImageFromFileName(fileName);
		}

		private Image GetImageFromFileName(string fileName)
		{
			string uri = "ms-appx:////Implementation/Pokemon/Assets/" + fileName;
			Image img = new Image();
			img.Source = new BitmapImage(new Uri(uri));
			return img;
		}
	}
}
