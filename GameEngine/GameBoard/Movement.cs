using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameBoard
{
	public static class Movement
	{
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public static void MoveCellObject(ICellObject cellObject, Area area, Direction direction)
		{
            var originalXCoordinate = cellObject.CoordinateTuple.x;
            var originalYCoordinate = cellObject.CoordinateTuple.y;

            var nextXCoordinate = originalXCoordinate;
            var nextYCoordinate = originalYCoordinate;

            switch (direction)
            {
                case Direction.Left:
                    if (originalXCoordinate > 1)
                        if (CheckIfNextCellIsPassable(nextXCoordinate - 1, nextYCoordinate, area))
                            nextXCoordinate--;

                    break;

                case Direction.Up:
                    if (originalYCoordinate > 1)
                        if(CheckIfNextCellIsPassable(nextXCoordinate,nextYCoordinate - 1,area))
                            nextYCoordinate--;

                    break;

                case Direction.Down:
                    if (originalYCoordinate < area.AreaGrid[0].Length)
                        if (CheckIfNextCellIsPassable(nextXCoordinate, nextYCoordinate + 1, area))
                            nextYCoordinate++;
                    
                    break;

                case Direction.Right:
                    if (originalXCoordinate < area.AreaGrid.Length)
                        if (CheckIfNextCellIsPassable(nextXCoordinate + 1, nextYCoordinate, area))
                            nextXCoordinate++;
                    
                    break;

                default: return;
            }

            area.AreaGrid[originalXCoordinate - 1][originalYCoordinate - 1].CellObjects.Remove(cellObject);
            area.AreaGrid[nextXCoordinate - 1][nextYCoordinate - 1].CellObjects.Add(cellObject);
            cellObject.CoordinateTuple = (nextXCoordinate, nextYCoordinate);

            TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate, area);
        }

        private static void TriggerEventHandlerInNextCellObject(int xPos, int yPos, Area area)
        {
            var cellObjects = area.AreaGrid[xPos - 1][yPos - 1].CellObjects;

            foreach (var cellObject in cellObjects)
            {
                //TODO: Find a way to trigger the events
            }
        }

        private static bool CheckIfNextCellIsPassable(int xPos, int yPos, Area area)
        {
            var cellObjects = area.AreaGrid[xPos - 1][yPos - 1].CellObjects;

            return cellObjects.All(cellObject => cellObject.IsPassable);
        }
    }
}
