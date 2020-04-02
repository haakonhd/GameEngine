using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
	class MediumHouse : ICellObject
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public Dictionary<double, Action> EventTriggers { get; set; } = new Dictionary<double, Action>();
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }

		public MediumHouse()
		{
			Sprite = new Sprite("house_2x2.png");
			IsPassable = false;
			EventTriggers.Add(1, new MediaHandler("bump.mp3").SoundPlayer.Play);
			CellWidth = 2;
			CellHeight = 2;
		}

		public ICellObject GetCopy()
		{
			throw new NotImplementedException();
		}
	}
}
