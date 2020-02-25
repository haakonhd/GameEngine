﻿using GameEngine.Factories;
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
	public sealed partial class GameWindow : Page
	{
		public StartGameParams StartGameParams { get; set; }
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

			StartGameParams = (StartGameParams)e.Parameter;
			if (StartGameParams == null) return;

			//Sets the title bar 
			var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
			appView.Title = StartGameParams.Game.Title;
			
			area = StartGameParams.Area;
			boardWidth = StartGameParams.Game.GameWidth;

			DrawBoard();
		}


		private void GenerateGrid()
		{

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
							MainGrid.Children.Add(img);
						}
					}
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
					// a new instance of Grass needs to be created in order to place it in the view more than once
					Image img = PrepareImageFromCellObject(CellObjectFactory.Build(cellObject.Key), x, y);
					MainGrid.Children.Add(img);
				}
			}
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

		public void DrawBoard()
		{
			if (area == null) return;
			GenerateGrid();
			if(area.BackgroundCellObject != null)
				FillBoardWithCellObject(area.BackgroundCellObject);
			InsertAllCellObjects(area);
		}

		void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
		{
			switch (e.VirtualKey)
			{
				case Windows.System.VirtualKey.Left:
					//Movement.MoveCellObjectLeft();
					break;
				default: return;
			}
		}

		//public void MoveCellOject(CellObject cellObject, )
	}
}