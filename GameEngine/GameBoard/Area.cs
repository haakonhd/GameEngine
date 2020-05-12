using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine
{
    /// <summary>
    /// Represents a playable area
    /// </summary>
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

        /// <summary>
        /// Initializing an area
        /// </summary>
        public Area()
        {
        }

        /// <summary>
        /// Initializing an area where you set the grid size in the contructor
        /// </summary>
        /// <param name="width">Width of the play area</param>
        /// <param name="height">Height of the play area</param>
        public Area(int width, int height)
        {
            SetAreaGrid(width, height);
        }

        /// <summary>
        /// Sets the size of the playable area
        /// </summary>
        /// <param name="width">Width of the play area</param>
        /// <param name="height">Height of the play area</param>
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

        /// <summary>
        /// Places an object in the grid
        /// </summary>
        /// <param name="xCoordinate">X coordinates</param>
        /// <param name="yCoordinate">Y Coordinates</param>
        /// <param name="cellObject">The object to placed in the grid</param>
        public void SetCellObjectGridPosition(int xCoordinate, int yCoordinate, ICellObject cellObject)
        {

            if(!GameObjects.Contains(cellObject))
                GameObjects.Add(cellObject);

            if (Width < xCoordinate + cellObject.CellWidth - 1)
                throw new System.ArgumentOutOfRangeException("(xCoordinate + cellWidth - 1)  is out of range.");

            if (Height < yCoordinate + cellObject.CellHeight - 1)
                throw new System.ArgumentOutOfRangeException("(yCoordinate + cellHeight - 1)  is out of range.");

            if (AreaGrid.Length > 0)
            {
                AreaGrid[xCoordinate - 1][yCoordinate - 1].CellObjects.Add(cellObject);

                //if cell objects are larger than 1x1 we insert invisible cells in the empty places
                
                //for each column we add an empty cell
                for (int width = 1; width <= cellObject.CellWidth; width++)
                {
                    //skip first cell since it is created above
                    if(width != 1)
                        AreaGrid[xCoordinate - 2 + width][yCoordinate - 1].CellObjects.Add(new EmptyCell(cellObject.EventTriggers));
                        // for each row we add an empty cell
                    for (int height = 1; height < cellObject.CellHeight; height++)
                        AreaGrid[xCoordinate - 2 + width][yCoordinate - 1 + height].CellObjects.Add(new EmptyCell(cellObject.EventTriggers));
                }
            }
            if (cellObject is IPlayableCharacter)
                cellObject.Position = (xCoordinate, yCoordinate);
        }
    }
}