using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace GameEngine.Implementation.EmptyProject.FactoryObjects
{
	class Sign : ICellObject
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public List<GameEvent> EventTriggers { get; set; } = new List<GameEvent>();
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
		private static bool toggleVisible = false;
		
		public Sign(string signMessage)
		{
			SetSprite();
			IsPassable = false;
			CellWidth = 1;
			CellHeight = 1;
			void action() { displayMessage(signMessage); }
			EventTriggers.Add(new GameEvent(1, action, GameEvent.EventTypes.Collision));
			
		}


		public void displayMessage(string message)
		{
			TextBox textBox = new TextBox();
			textBox.Text = message;
			textBox.Width = 200;
			textBox.Height = 70;

			textBox.VerticalAlignment = VerticalAlignment.Center;
			textBox.HorizontalAlignment = HorizontalAlignment.Center;
			textBox.TextWrapping = TextWrapping.Wrap;

			if (toggleVisible == false)
			{
				Game.Instance.CustomUIElementsToBeAdded.Add(textBox);
				toggleVisible = true;
			}
			else
			{
				var element = Game.Instance.CustomUIElementsInView.Find(x => x.GetType() == typeof(TextBox));
				Game.Instance.CustomUIElementsInView.Remove(element);
				Game.Instance.CustomUIElementsToBeDeleted.Add(element);
				toggleVisible = false;
			}

		}

		public void SetSprite()
		{
			Sprite = new Sprite("sign.png");
		}
	}
}
