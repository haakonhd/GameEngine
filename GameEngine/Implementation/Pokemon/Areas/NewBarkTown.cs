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
	public sealed class NewBarkTown : IAreaSingleton
	{
		private static readonly object padlock = new object();
		private static NewBarkTown instance = null;
		public Area Area { get; set; }


		public static NewBarkTown Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new NewBarkTown();
						instance.resetArea();
					}
					return instance;
				}
			}
		}

		public NewBarkTown()
		{
		}

		public void resetArea()
		{
			Area = new Area();
			int areaWidth = 20;
			int areaHeight = 14;
			Area.SetAreaGrid(areaWidth, areaHeight);
			Area.BackgroundCellObject = CellObjectFactory.Build(CellObjectType.Grass);
			//Area.AreaMusic = new MediaHandler("new_bark_town.mp3");
			Area.AreaMusic = new MediaHandler("");

			ICellObject N = CellObjectFactory.Build(CellObjectType.Npc);
			ICellObject E = CellObjectFactory.Build(CellObjectType.Enemy);
			ICellObject S = CellObjectFactory.Build(CellObjectType.SmallHouse);
			ICellObject M = CellObjectFactory.Build(CellObjectType.MediumHouse);
			ICellObject B = CellObjectFactory.Build(CellObjectType.BigHouse);
			ICellObject T = CellObjectFactory.Build(CellObjectType.Tree);
			ICellObject V = CellObjectFactory.Build(CellObjectType.Merchant);
			ICellObject P = new Portal(RouteOne.Instance.Area, (30, 7), GameEvent.EventTypes.Enter, true, RouteOne.Instance);
			ICellObject p = new Portal(RouteOne.Instance.Area, (30, 8), GameEvent.EventTypes.Enter, true, RouteOne.Instance);
			ICellObject _ = null;
			ICellObject x = null;
			ICellObject I = null;

			ICellObject[][] area =
				{ 
					//				   1				 10					 20
					//                 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
					new ICellObject[]{ T,T,T,T,T,T,B,x,x,x,x,x,T,T,T,T,T,T,T,T }, //1
					new ICellObject[]{ I,I,I,I,I,I,x,_,_,_,_,x,I,I,I,I,I,I,I,I }, //2
					new ICellObject[]{ T,T,T,_,_,_,x,_,_,_,_,x,_,_,M,x,x,x,T,T }, //3
					new ICellObject[]{ I,I,_,_,_,_,x,x,x,x,x,x,_,_,x,_,_,x,I,I }, //4
					new ICellObject[]{ T,T,_,_,_,_,N,_,_,_,_,_,_,_,x,_,_,x,_,T }, //5
					new ICellObject[]{ I,I,_,_,_,_,_,_,_,_,_,_,_,_,x,x,x,x,_,I }, //6
					new ICellObject[]{ P,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,T }, //7
					new ICellObject[]{ p,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,E,_,_,I }, //8
					new ICellObject[]{ T,T,T,T,S,x,x,x,_,_,_,_,_,_,_,_,_,_,T,T }, //9
					new ICellObject[]{ I,I,I,I,x,x,x,x,_,_,_,_,S,x,x,x,_,_,I,I }, //10
					new ICellObject[]{ T,T,_,V,_,_,_,_,_,_,_,_,x,x,x,x,_,_,T,T }, //11
					new ICellObject[]{ I,I,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,I,I }, //12
					new ICellObject[]{ T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T }, //13
					new ICellObject[]{ I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I }  //14
				};

			for (int i = 0; i < areaHeight - 1; i++)
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
