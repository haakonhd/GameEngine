using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace GameEngine.GameObjects
{
	/// <summary>
	/// An image to be displayed in the game board
	/// </summary>
	public class Sprite
	{
		public Image SpriteImage { get; private set; }

		public Sprite()
		{
		}
		
		/// <summary>
		/// Create a sprite with an image
		/// </summary>
		/// <param name="fileName">Name of file found in assets</param>
		public Sprite(string fileName)
		{
			SetSpriteFromFileName(fileName);
		}

		/// <summary>
		/// Set the sprite image from a filename
		/// </summary>
		/// <param name="fileName">Filename of image</param>
		public void SetSpriteFromFileName(string fileName)
		{
			SpriteImage = GetImageFromFileName(fileName);
		}

		/// <summary>
		/// Create an image control
		/// </summary>
		/// <param name="fileName">Filename of image</param>
		/// <returns></returns>
		private Image GetImageFromFileName(string fileName)
		{
			string uri = "ms-appx:///Implementation/" + Game.Instance.GamePathName + "/Assets/" + fileName;
			Image img = new Image();
			img.Source = new BitmapImage(new Uri(uri));
			return img;
		}
	}
}
