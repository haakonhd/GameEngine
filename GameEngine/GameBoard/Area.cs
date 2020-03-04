using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine
{
    public class Area
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Jagged array is needed for area grid to work")]
        public Cell[][] AreaGrid { get; private set; }
        public ICellObject BackgroundCellObject { get; set; }
        public MediaHandler AreaMusic { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public List<ICellObject> GameObjects = new List<ICellObject>();

        public List<ICellEntity> GameEntities = new List<ICellEntity>();

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
        public void SetCellObjectGridPosition(int xCoordinate, int yCoordinate, ICellObject cellObject)
        {
            if(!GameObjects.Contains(cellObject))
                GameObjects.Add(cellObject);

            if(AreaGrid.Length > 0)
            {
                AreaGrid[xCoordinate - 1][yCoordinate - 1].CellObjects.Add(cellObject);
                //TODO: Can't use Hero here
                if (cellObject is Hero)
                    cellObject.Position = (xCoordinate, yCoordinate);
            }
        }
    }
}