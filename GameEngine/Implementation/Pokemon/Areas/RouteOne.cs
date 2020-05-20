using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Events;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;
using GameEngine.GameBoard;

namespace GameEngine.Implementation.Pokemon.Areas
{
	public sealed class RouteOne : IAreaSingleton
	{
		private static readonly object padlock = new object();
		private static RouteOne instance = null;
		public Area Area { get; set; }
		public static RouteOne Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new RouteOne();
						instance.resetArea();
					}
					return instance;
				}
			}
		}

		public RouteOne()
		{
		}

		public void resetArea()
		{
			Area = new Area();
			int areaWidth = 30;
			int areaHeight = 12;
			Area.SetAreaGrid(areaWidth, areaHeight);
			Area.BackgroundCellObject = CellObjectFactory.Build(CellObjectType.Grass);
			Area.AreaMusic = new MediaHandler("route_one.mp3");
			//Area.AreaMusic = new MediaHandler("");

			ICellObject N = CellObjectFactory.Build(CellObjectType.Npc);
			ICellObject E = CellObjectFactory.Build(CellObjectType.Enemy);
			ICellObject S = CellObjectFactory.Build(CellObjectType.SmallHouse);
			ICellObject M = CellObjectFactory.Build(CellObjectType.MediumHouse);
			ICellObject B = CellObjectFactory.Build(CellObjectType.BigHouse);
			ICellObject T = CellObjectFactory.Build(CellObjectType.Tree);
			ICellObject H = CellObjectFactory.Build(CellObjectType.FancyHouse);
			ICellObject F = CellObjectFactory.Build(CellObjectType.Flower);
			ICellObject P = new Portal(NewBarkTown.Instance.Area, (1, 7), GameEvent.EventTypes.Enter, true, NewBarkTown.Instance);
			ICellObject p = new Portal(NewBarkTown.Instance.Area, (1, 8), GameEvent.EventTypes.Enter, true, NewBarkTown.Instance);
			ICellObject _ = null;
			ICellObject x = null;
			ICellObject I = null;

			ICellObject[][] area =
			{	//				   1				   10				 20					 30
				//                 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
				new ICellObject[]{ T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T }, //1
				new ICellObject[]{ I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I }, //2
				new ICellObject[]{ T,T,T,T,T,T,T,T,H,x,x,x,x,_,_,_,_,_,T,T,T,T,T,T,T,T,T,T,T,T }, //3
				new ICellObject[]{ I,I,I,I,I,I,I,I,x,_,_,_,x,_,_,_,F,_,I,I,I,I,I,I,I,I,I,I,I,I }, //4
				new ICellObject[]{ T,_,F,F,F,F,_,_,x,_,_,_,x,_,_,F,_,_,_,_,_,_,_,_,_,_,_,_,_,T }, //5
				new ICellObject[]{ I,_,F,F,F,F,_,_,x,x,x,x,x,_,_,_,_,_,_,_,_,_,_,F,_,_,_,_,_,I }, //6
				new ICellObject[]{ T,_,F,F,F,F,_,_,_,_,_,_,_,_,_,_,_,F,_,_,_,_,_,_,_,_,_,_,_,P }, //7
				new ICellObject[]{ I,_,_,_,_,_,_,_,_,_,_,_,_,_,F,_,_,_,_,_,_,_,_,_,_,F,_,_,_,p }, //8
				new ICellObject[]{ T,_,_,F,_,_,_,_,_,_,_,_,F,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,T }, //9
				new ICellObject[]{ I,_,_,_,_,_,_,_,F,_,_,_,_,_,_,_,_,F,F,F,F,_,_,_,_,_,_,_,_,I }, //10
				new ICellObject[]{ T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T }, //11
				new ICellObject[]{ I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I }, //12

			};

			for (int i = 0; i < areaHeight; i++)
			{
				for (int j = 0; j <= areaWidth - 1; j++)
				{
					if (area[i][j] != null)
						Area.SetCellObjectGridPosition(j + 1, i + 1, area[i][j]);
				}
			}
		}

	}
}
