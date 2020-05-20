using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects.Inanimate_objects
{
	class FancyHouse : ICellObject
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
		public List<GameEvent> EventTriggers { get; set; } = new List<GameEvent>();

		public FancyHouse()
		{
			SetSprite();
			IsPassable = false;
			EventTriggers.Add(new GameEvent(1, new MediaHandler("bump.mp3").SoundPlayer.Play, GameEvent.EventTypes.Collision));
			CellWidth = 5;
			CellHeight = 4;
		}


		public void SetSprite()
		{
			this.Sprite = new Sprite("house_5x4.png");
		}
	}
}
