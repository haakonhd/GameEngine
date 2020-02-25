using GameEngine.Factories;
using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	class Hero : ICellObject, IFighter
	{
		public int HealthPoints { get; set; }
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public string Key { get; set; }
		public List<IEvent> EventTriggers { get; set; }

		public Hero()
		{
			Sprite = new Sprite("hero.png");
			IsPassable = true;
			HealthPoints = 20;
			Key = "HERO";
			EventTriggers = null;
		}
	}
}
