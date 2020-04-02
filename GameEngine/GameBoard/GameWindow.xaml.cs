using GameEngine.GameObjects;
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
			
			area = Game.CurrentArea;
			boardWidth = Game.GameWidth;

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
							if (cellObject != null)
								InsertCellObject(cellObject, x, y, cellObject.CellHeight, cellObject.CellWidth);
						}
					}
				}
			}
		}

		// row and column span is how many cells the object should span over. rowSpan=1 columnSpan=2 will create a 1x2 object
		public void InsertCellObject(ICellObject cellObject, int xPos, int yPos, int rowSpan, int columnSpan)
		{
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
                if (entity.EntityLifetime >= Game.StopWatch.ElapsedMilliseconds)
                {
					if(!MainGrid.Children.Contains((UIElement)entity.Entity))
					    MainGrid.Children.Add((UIElement)entity.Entity);
                }
                else
                {
                    MainGrid.Children.Remove((UIElement) entity.Entity);
                    area.GameEntities.Remove(entity);
					return;
                }
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
					// a new instance of background-object needs to be created in order to place it in the view more than once
					InsertCellObject(cellObject.GetCopy(), x, y, cellObject.CellHeight, cellObject.CellWidth);
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
			
            switch (e.VirtualKey)
			{
				case VirtualKey.Left:
                    Movement.MoveCellObject(heroCellObject,area, Direction.Left);
                    break;

                case VirtualKey.Right:
                    Movement.MoveCellObject(heroCellObject, area, Direction.Right);
                    break;

                case VirtualKey.Up:
                    Movement.MoveCellObject(heroCellObject, area, Direction.Up);
                    break;

                case VirtualKey.Down:
                    Movement.MoveCellObject(heroCellObject, area, Direction.Down);
                    break;

				case VirtualKey.E:
                    //Movement.InteractWithCellObject(heroCellObject, area);
					
					area.GameEntities.Add(new ChatBubble(3000, "Hey", 5, 1));

                    break;

				default: return;
            }
            
		}

	}
}
