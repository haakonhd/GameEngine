using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace GameEngine.Tools
{
	class SpriteHandler
	{
		internal Image GetImageFromFileName(string fileName)
		{
			string uri = "ms-appx:///Assets/" + fileName;
			Image img = new Image();
			img.Source = new BitmapImage(new Uri(uri));
			return img;
		}
	}
}
