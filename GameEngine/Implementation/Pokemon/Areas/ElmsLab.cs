using GameEngine.Events;
using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;

namespace GameEngine.Implementation.Pokemon.Areas
{
	public sealed class ElmsLab : IAreaSingleton
	{
		private static readonly object padlock = new object();
		private static ElmsLab instance = null;
		public Area Area { get; set; }


		public static ElmsLab Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new ElmsLab();
						instance.resetArea();
					}
					return instance;
				}
			}
		}

		public ElmsLab()
		{
		}

		public void resetArea()
		{
			Area = new Area();
			int areaWidth = 10;
			int areaHeight = 7;
			Area.SetAreaGrid(areaWidth, areaHeight);
			Area.BackgroundCellObject = CellObjectFactory.Build(CellObjectType.Floor);
			Area.AreaMusic = new MediaHandler("shop.mp3");

			ICellObject N = CellObjectFactory.Build(CellObjectType.Npc);
			ICellObject L = CellObjectFactory.Build(CellObjectType.LabThing);
			ICellObject B = CellObjectFactory.Build(CellObjectType.Bookshelf);
			ICellObject R = CellObjectFactory.Build(CellObjectType.Rug);
			ICellObject P = new Portal(NewBarkTown.Instance.Area, (9, 5), GameEvent.EventTypes.Enter, true, NewBarkTown.Instance);
			ICellObject _ = null;
			ICellObject x = null;

			ICellObject[][] area =
				{ 
				//				   1				 10	
				//                 1 2 3 4 5 6 7 8 9 0 
				new ICellObject[]{ _,B,x,_,_,_,_,_,_,_}, //1
				new ICellObject[]{ _,_,_,_,N,_,_,_,_,_}, //2
				new ICellObject[]{ _,B,x,_,_,_,_,L,x,_}, //3
				new ICellObject[]{ _,_,_,_,_,_,_,_,_,_}, //4
				new ICellObject[]{ _,_,_,_,_,_,_,_,_,_}, //5
				new ICellObject[]{ L,x,_,_,_,_,_,_,_,_}, //6
				new ICellObject[]{ _,_,_,_,P,P,_,_,_,_}, //7
			};



			for (int i = 0; i < areaHeight; i++)
			{
				for (int j = 0; j <= areaWidth - 1; j++)
				{
					if (area[i][j] != null)
						Area.SetCellObjectGridPosition(j + 1, i + 1, area[i][j]);
				}
			}

			//Placing a rug over the portal
			Area.SetCellObjectGridPosition(5, 7, R);
		}
	}
}
