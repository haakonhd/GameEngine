using GameEngine.GameObjects;
using GameEngine.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameEngine.GameBoard
{
	/// <summary>
	/// This is the page where the game board is drawn
	/// </summary>
	public sealed partial class VisualGameBoard : Page
	{
		public StartGameParams StartGameParams { get; set; }
		private Area area { get; set; }
		private int boardWidth { get; set; }
		private int boardHeight { get; set; }
		private int cellSize { get; set; }

		public VisualGameBoard()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			StartGameParams = (StartGameParams)e.Parameter;
			if (StartGameParams == null) return;
			area = StartGameParams.Area;
			boardWidth = StartGameParams.BoardWidth;
			boardHeight = StartGameParams.BoardHeight;

			DrawBoard();
		}


		private void GenerateGrid()
		{
			// for some reason MainGrid disappears if I set its vertical alignment..
			// workaround: a container for MainGrid, placed in the center of the screen
			OuterGrid.Height = boardHeight;

			//cells are squared. their size is based on the boards width
			cellSize = boardWidth / area.Width;

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

		private void InsertCellObjects()
		{
			//for each column
			for (int x = 0; x < area.Width; x++)
			{
				//for each row 
				for (int y = 0; y < area.Height; y++)
				{
					Grass grass = new Grass();
					Image grassImg = grass.Sprite.SpriteImage;
					grassImg.SetValue(Grid.ColumnProperty, x);
					grassImg.SetValue(Grid.RowProperty, y);
					grassImg.Width = cellSize;
					grassImg.Height = cellSize;
					MainGrid.Children.Add(grassImg);

					if (area.AreaGrid[x][y].CellObjects.Count > 0)
					{
						foreach (CellObject cellObject in area.AreaGrid[x][y].CellObjects)
						{
							Image img = cellObject.Sprite.SpriteImage;
							img.SetValue(Grid.ColumnProperty, x);
							img.SetValue(Grid.RowProperty, y);
							img.Width = cellSize;
							img.Height = cellSize;
							MainGrid.Children.Add(img);
						}
					}
				}
			}


		}

		public void DrawBoard()
		{
			if (area == null) return;
			GenerateGrid();
			InsertCellObjects();
		}
	}
}
