﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Area
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Jagged array is needed for area grid to work")]
        public Cell[][] AreaGrid { get; private set; }
        public MediaHandler AreaMusic { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Area()
        {
        }

        public Area(int width, int height)
        {
            SetAreaGrid(width, height);
        }

        public void SetAreaGrid(int width, int height)
        {
            int y = 0;
            // instantiate area grid with a cell object in each cell
            AreaGrid = new Cell[width][];
            for (int x = 0; x < width; x++)
            {
                AreaGrid[x] = new Cell[height];
                //AreaGrid[x] = new Cell[height];
                for (y = 0; y < height; y++)
                {
                    AreaGrid[x][y] = new Cell();
                }
            }
            Width = width;
            Height = height;
        }

        //TODO: Check that index exists
        public void PlaceObjectToGrid(int xCoordinate, int yCoordinate, CellObject cellObject)
        {
            if(AreaGrid.Length > 0)
            {
                //AreaGrid[xCoordinate - 1][yCoordinate - 1].CellObjects = new List<CellObject>();
                AreaGrid[xCoordinate - 1][yCoordinate - 1].CellObjects.Add(cellObject);
            }
        }
    }
}