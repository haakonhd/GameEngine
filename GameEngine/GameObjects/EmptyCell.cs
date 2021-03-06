﻿using GameEngine.Events;
using GameEngine.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
	class EmptyCell : ICellObject
	{
		public Sprite Sprite { get; set; }
		public bool IsPassable { get; set; }
		public (int x, int y) Position { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
		public List<GameEvent> EventTriggers { get; set; }

		public EmptyCell(List<GameEvent> eventTriggers)
		{
			this.Sprite = new Sprite("");
			IsPassable = false;
			EventTriggers = eventTriggers;
			CellWidth = 1;
			CellHeight = 1;
		}

		public EmptyCell()
		{

		}

		public void SetSprite()
		{
			this.Sprite = new Sprite("");
		}
	}
}
