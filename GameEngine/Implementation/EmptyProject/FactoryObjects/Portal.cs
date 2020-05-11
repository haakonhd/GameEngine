using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngine.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.FactoryObjects
{
	/// <summary>
	/// Cell object that triggers travel event. 
	/// </summary>
	class Portal : ICellObject
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public List<GameEvent> EventTriggers { get; set; } = new List<GameEvent>();
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
		public Area NewArea { get; set; }
		public (int x, int y) StartPos { get; set; }
		public static int count = 0;


	/// <summary>
	/// ALKSDASD
	/// </summary>
	/// <param name="newArea"></param>
	/// <param name="startPos"></param>
	/// <param name="eventType"></param>
	/// <param name="isPassable"></param>
		public Portal(Area newArea, (int x, int y) startPos, GameEvent.EventTypes eventType, bool isPassable)
		{
			Sprite = new Sprite("");
			IsPassable = isPassable;
			CellWidth = 1;
			CellHeight = 1;
			NewArea = newArea;
			void travel() { HelperMethods.Travel(startPos, newArea); }
			EventTriggers.Add(new GameEvent(1, travel, eventType));
			StartPos = startPos;
		}



		public void SetSprite()
		{
			Sprite = new Sprite("");
		}
	}
}
