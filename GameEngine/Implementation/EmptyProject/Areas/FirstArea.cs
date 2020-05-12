using GameEngine.Events;
using GameEngine.GameObjects;
using GameEngine.Implementation.EmptyProject.Factories;
using static GameEngine.Implementation.EmptyProject.Factories.CellObjectFactory;

namespace GameEngine.Implementation.EmptyProject.Areas
{
	/// <summary>
	/// Singleton. The first area of the game
	/// </summary>
	public sealed class FirstArea
	{
		private static readonly object padlock = new object();
		private static FirstArea instance = null;
		public Area Area { get; set; }
		/// <summary>
		/// Retrieves a static instance of firstArea
		/// </summary>
		public static FirstArea Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new FirstArea();
					}
					return instance;
				}
			}
		}

		public FirstArea()
		{
			Area = new Area();
			//Set how many cells the area should have
			int areaWidth = 30;
			int areaHeight = 12;
			Area.SetAreaGrid(areaWidth, areaHeight);
			//Set a sprite that will fill the entire board
			Area.BackgroundCellObject = CellObjectFactory.Build(CellObjectType.Grass);
			//Upload a tune to the assets folder and play it when the player enters the area
			Area.AreaMusic = new MediaHandler("firstAreaMusic.mp3");

			//To easily build an area, you can bind each object you plan to use on the screen in a single character
			//variable. You can then draw the board using code like below. Cell objects with "null" will be empty.

			//If you want to place more than one object in a cell you can either place it into the code like so:
			//Area.SetCellObjectGridPosition(8,8,cellObject);
			//Or draw a new area with another two dimentional array and place it on top of the other one
			
			//To move to a new area you can create a portal and select the new area like below. instead of "FirstArea" you can
			//enter the area the portal shall lead to, the start position, how the event will be triggered and if the cell
			//can be stepped on
			//ICellObject P = new Portal(FirstArea.Instance.Area, (1,7), GameEvent.EventTypes.Enter, true);
			ICellObject T = CellObjectFactory.Build(CellObjectType.Tree);

			ICellObject _ = null;
			ICellObject I = null;
			//hero position
			ICellObject x = null;

			ICellObject[][] area =
			{	//				   1				   10				 20					 30
				//                 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
				new ICellObject[]{ T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T }, //1
				new ICellObject[]{ I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I }, //2
				new ICellObject[]{ T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T }, //3
				new ICellObject[]{ I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I }, //4
				new ICellObject[]{ T,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,T }, //5
				new ICellObject[]{ I,_,_,_,_,x,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,I }, //6
				new ICellObject[]{ I,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,I }, //7
				new ICellObject[]{ I,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,I }, //8
				new ICellObject[]{ I,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,I }, //9
				new ICellObject[]{ I,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,I }, //10
				new ICellObject[]{ I,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,T,I }, //11
				new ICellObject[]{ I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I,I }  //12
			};

			//Can't touch this
			for (int i = 0; i < areaHeight - 1; i++)
			{
				for (int j = 0; j <= areaWidth - 1; j++)
				{
					if (area[i][j] != null)
						Area.SetCellObjectGridPosition(j + 1, i + 1, area[i][j]);
				}
			}

			/*
			  
					 ,-===-.     _
					:__   __:   (#)
		 ______     [__]=[__]    \\ _
		'---___) ) (|  c_)  |)  ((\( 3 ))
		   /  /     |.-=_=-.|     \  \
		  /  /       \ \_/ /       \  \
		 /  /__.------`---'------.__\  \
		/      \      \ # /      /      \
		`-------\      \#/      /-------' ))
				 \      /  --- /
				  \     |o    /
				   \    |o   /
					\   |o  /
			  ______ >-----<_______
		  (( \                     /
			  \                   /
			   \                 /
				\   .-------.   /
				 \   \     /   /
				  \   \   /   /
				 __\___\ /___/__
				'----^-' '-^----' ))
 
			 */
		}
	}
}
