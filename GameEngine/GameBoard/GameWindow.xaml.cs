using GameEngine.Implementation.Pokemon.FactoryObjects;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static GameEngine.GameBoard.Movement;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameEngine.GameBoard
{
    /// <summary>
	/// This is the page where the game board is drawn
	/// </summary>
	public sealed partial class GameWindow : Page
	{
        public Game Game { get; set; }
		private Area area { get; set; }
		private int boardWidth { get; set; }
		private int cellSize { get; set; }

		public GameWindow()
		{
			InitializeComponent();

			//Test
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
            // listen for keypress
			Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

            Game = (Game)e.Parameter;
			if (Game == null) return;

			//Sets the title bar 
			var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
			appView.Title = Game.Title;

            Movement.CurrentGameState = ControllerState.Movement;
			
			area = Game.CurrentArea;
			boardWidth = Game.GameWidth;

            ChatBox.Width = Game.GameWidth - Game.GameWidth / 10;
			ChatBox.Margin = new Thickness(0,0,0,Game.GameWidth/25);

			Game.StopWatch.Start();

			DrawBoard();

			CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

		private void CompositionTarget_Rendering(object sender, object e)
		{
			InsertAllCellObjects(area);
            InsertAllCellEntities(area);
        }


        private void GenerateGrid()
        {
            if (MainGrid.ColumnDefinitions.Count > 0 && MainGrid.RowDefinitions.Count > 0)
                return;

			//cells are squared. their size is based on the boards width
			cellSize = boardWidth / area.Width;

			// for some reason MainGrid disappears if I set its vertical alignment..
			// workaround: a container for MainGrid, placed in the center of the screen
			OuterGrid.Height = area.Height * cellSize;

			//for each column
			for (int x = 0; x < area.Width; x++)
			{
				ColumnDefinition col = new ColumnDefinition();
				col.Width = new GridLength(cellSize);
				MainGrid.ColumnDefinitions.Add(col);

				//for  each row
				for (int y = 0; y < area.Height; y++)
				{
					RowDefinition row = new RowDefinition();
					row.Height = new GridLength(cellSize);
					MainGrid.RowDefinitions.Add(row);
				}
			}
		}
			
		public void InsertAllCellObjects(Area area)
		{
			if (area == null) return;
			//for each column
			for (int x = 0; x < area.Width; x++)
			{
				//for each row 
				for (int y = 0; y < area.Height; y++)
				{
					if (area.AreaGrid[x][y].CellObjects.Count > 0)
					{
						//place all cellObjects to the board 
						foreach (ICellObject cellObject in area.AreaGrid[x][y].CellObjects)
						{
                            Image img = PrepareImageFromCellObject(cellObject, x, y);
							if(!MainGrid.Children.Contains(img))
							    MainGrid.Children.Add(img);
						}
					}
				}
			}
		}

        private void InsertAllCellEntities(Area area)
        {
			if(area.GameEntities.Count == 0)
				return;

            foreach (var entity in area.GameEntities)
            {
 
            }
        }

		public void FillBoardWithCellObject(ICellObject cellObject)
		{
			if (cellObject == null) return;
			//for each column
			for (int x = 0; x < area.Width; x++)
			{
				//for each row 
				for (int y = 0; y < area.Height; y++)
				{
					// a new instance of Grass needs to be created in order to place it in the view more than once
					Image img = PrepareImageFromCellObject(cellObject.GetCopy(), x, y);
					MainGrid.Children.Add(img);
				}
			}
		}

		public void InsertXamlControl(Control control)
		{
			OuterGrid.Children.Add(control);
		}

		private Image PrepareImageFromCellObject(ICellObject cellObject, int columnProperty, int rowProperty)
		{
			Image img = cellObject.Sprite.SpriteImage;
			img.SetValue(Grid.ColumnProperty, columnProperty);
			img.SetValue(Grid.RowProperty, rowProperty);
			img.Width = cellSize;
			img.Height = cellSize;
			return img;
		}

		// whipes the current board and draws a new one from area object
		public void DrawBoard()
		{
            if (area == null) 
                return;

            MainGrid.Children.Clear();

			GenerateGrid();

            if(area.BackgroundCellObject != null)
				FillBoardWithCellObject(area.BackgroundCellObject);

			InsertAllCellObjects(area);
		}

        void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {
			//TODO: Can't reference Hero
            var heroCellObject = area.GameObjects.Find(x => x.GetType() == typeof(Hero));

            Movement.HandleInput(e.VirtualKey, heroCellObject);
        }

	}
}
