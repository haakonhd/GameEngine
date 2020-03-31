using System.Linq;

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
            var originalXCoordinate = cellObject.Position.x;
            var originalYCoordinate = cellObject.Position.y;

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
            cellObject.Position = (nextXCoordinate, nextYCoordinate);

            TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate, area);
        }

        private static void TriggerEventHandlerInNextCellObject(int xPos, int yPos, Area area)
        {
            var cellObjects = area.AreaGrid[xPos - 1][yPos - 1].CellObjects;
            if(cellObjects.Count > 0)
            {
                foreach (var cellObject in cellObjects)
                {
                    //TODO: Find a way to trigger the events
                    if(cellObject.EventTriggers == null || cellObject.EventTriggers.Count == 0)
                        continue;

                    //cellObject.EventTriggers[0].GameEvent();
                }
            }
        }

        private static bool CheckIfNextCellIsPassable(int xPos, int yPos, Area area)
        {
            var cellObjects = area.AreaGrid[xPos - 1][yPos - 1].CellObjects;

            //TriggerEventHandlerInNextCellObject(xPos, yPos, area);

            return cellObjects.All(cellObject => cellObject.IsPassable);
        }

        public static void InteractWithCellObject(ICellObject cellObject, Area area)
        {
            int xPos = cellObject.Position.x;
            int yPos = cellObject.Position.y;

            TriggerEventHandlerInNextCellObject(xPos-1,yPos,area);
            TriggerEventHandlerInNextCellObject(xPos+1,yPos,area);
            TriggerEventHandlerInNextCellObject(xPos,yPos-1,area);
            TriggerEventHandlerInNextCellObject(xPos,yPos+1,area);
        }
    }
}
