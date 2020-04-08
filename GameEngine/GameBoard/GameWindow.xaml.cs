using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Areas;
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
        //public Game Game { get; set; }
		//private Area area { get; set; }
		private int boardWidth { get; set; }
		private int cellSize { get; set; }
		private static bool firstRender = true;
		public static bool renderIsInProgress = false;
		public static int counter = 0;
		//static Grid mainGrid;
		

		public GameWindow()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			firstRender = true;
			// listen for keypress
			Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

			var game = Game.Instance ;
			if (game == null) return;

			//game.Reload = Reload;

			//Sets the title bar 
			var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
			appView.Title = game.Title;

			game.CurrentGameState = Game.GameState.Movement;

			//game.CurrentArea = game.CurrentArea;
			boardWidth = game.GameWidth;

            ChatBox.Width = game.GameWidth - game.GameWidth / 10;
			ChatBox.Margin = new Thickness(0,0,0, game.GameWidth/25);
            ChatBox.Visibility = Visibility.Collapsed;

			game.StopWatch.Start();
			game.CurrentlyPlayingMusic = game.CurrentArea?.AreaMusic;
			game.CurrentlyPlayingMusic?.SoundPlayer.Play();

			DrawBoard();

			CompositionTarget.Rendering += CompositionTarget_Rendering;
			renderIsInProgress = false;
        }

        private void InitializeNewArea()
        {
            if (Game.Instance.CurrentArea == Game.Instance.NextArea)
                return;

            if (MainGrid.Children.Count != 0)
                MainGrid.Children.Clear();

            Game.Instance.CurrentArea = Game.Instance.NextArea;
            DrawBoard();
		}

        private void CompositionTarget_Rendering(object sender, object e)
		{
			//preventing functions from being run twice at the same time
			if (!renderIsInProgress)
            {
                InitializeNewArea();

				//if(mainGrid != null)
				//MainGrid = mainG/*r*/id;

				InsertAllCellObjects(Game.Instance.CurrentArea);
				//InsertAllCellEntities(Game.Instance.CurrentArea);

				//mainGrid = MainGrid;
			}
        }


        private void GenerateGrid()
        {
			var area = Game.Instance.CurrentArea;

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

			renderIsInProgress = true;

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
							if (cellObject != null)
							{
								if (firstRender)
								{
									cellObject.SetSprite();
								}
								InsertCellObject(cellObject, x, y, cellObject.CellHeight, cellObject.CellWidth);
							}
						}
					}
				}
			}
			renderIsInProgress = false;
			firstRender = false;
		}


		public void Reload()
		{
			renderIsInProgress = true;
			var game = Game.Instance;
			//game.CurrentArea.SetCellObjectGridPosition(game.PlayableCharacter.Position.x, game.PlayableCharacter.Position.y, game.PlayableCharacter);
			//MainGrid.Children.Clear();

			//Frame.Navigate(typeof(GameWindow), game);

			MainGrid.Children.Clear();
			//mainGrid = null;
			int i = 2;
		}

		// row and column span is how many cells the object should span over. rowSpan=1 columnSpan=2 will create a 1x2 object
		public void InsertCellObject(ICellObject cellObject, int xPos, int yPos, int rowSpan, int columnSpan)
		{
			var game = Game.Instance;
			Image img = PrepareImageFromCellObject(cellObject);
			SetImageGridProperties(img, xPos, yPos, rowSpan, columnSpan);

			if (!MainGrid.Children.Contains(img))
                MainGrid.Children.Add(img);
		}

        private void InsertAllCellEntities(Area area)
        {
			if(area.GameEntities.Count == 0)
				return;

            foreach (var entity in area.GameEntities)
            {
 
            }
        }

		public void FillBoardWithOneCellObject(ICellObject cellObject)
		{
			var area = Game.Instance.CurrentArea;
			if (cellObject == null) return;
			//for each column
			for (int x = 0; x < area.Width; x++)
			{
				//for each row 
				for (int y = 0; y < area.Height; y++)
				{
					// a new instance of background-object needs to be created in order to place it in the view more than once
					cellObject.SetSprite();
					InsertCellObject(cellObject, x, y, cellObject.CellHeight, cellObject.CellWidth);
				}
			}
		}

		public void InsertXamlControl(Control control)
		{
			OuterGrid.Children.Add(control);
		}

		private Image PrepareImageFromCellObject(ICellObject cellObject)
		{
			Image img = cellObject.Sprite.SpriteImage;
			img.Width = cellSize * cellObject.CellWidth;
			img.Height = cellSize * cellObject.CellHeight;
			return img;
		}

		private void SetImageGridProperties(Image image, int xPos, int yPos, int rowSpan, int columnSpan)
		{
			image.SetValue(Grid.ColumnProperty, xPos);
			image.SetValue(Grid.RowProperty, yPos);
			image.SetValue(Grid.RowSpanProperty, rowSpan);
			image.SetValue(Grid.ColumnSpanProperty, columnSpan);

		}

		// whipes the current board and draws a new one from area object
		public void DrawBoard()
		{
			var area = Game.Instance.CurrentArea;

			if (area == null) 
                return;

			//OuterGrid.Children.Clear();
			//MainGrid = new Grid();
			//OuterGrid.Children.Add(MainGrid);
            //MainGrid.Children.Clear();
			GenerateGrid();

            if(area.BackgroundCellObject != null)
				FillBoardWithOneCellObject(area.BackgroundCellObject);
		}


		void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {
			//TODO: Can't reference Hero
            var heroCellObject = Game.Instance.CurrentArea.GameObjects.Find(x => x.GetType() == typeof(Hero));

            KeyboardInputHandler.HandleInput(e.VirtualKey, heroCellObject);
        }

	}
}
