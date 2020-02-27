using GameEngine.Factories;
using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	class Grass : ICellObject
	{
		public Sprite Sprite {get; set ; }
		public bool IsPassable { get; set; }
		public string Key { get; set; }
		public List<IGameEvent> EventTriggers { get; set; }
		public (int x, int y) Position { get; set ; }

		public Grass()
		{
			Sprite = new Sprite("grass.png");
			IsPassable = true;
			Key = "GRASS";
			EventTriggers = null;
		}

	}
}
