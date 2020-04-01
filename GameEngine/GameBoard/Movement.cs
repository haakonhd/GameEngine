﻿using GameEngine.Events;
using GameEngine.Tools;
using System;
using System.Collections.Generic;
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
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate - 1, nextYCoordinate, area);

                    break;

                case Direction.Up:
                    if (originalYCoordinate > 1) 
                        if (CheckIfNextCellIsPassable(nextXCoordinate, nextYCoordinate - 1, area))
                            nextYCoordinate--;
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate - 1, area);

                    break;

                case Direction.Down:
                    if (originalYCoordinate < area.AreaGrid[0].Length)
                        if (CheckIfNextCellIsPassable(nextXCoordinate, nextYCoordinate + 1, area))
                            nextYCoordinate++;
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate + 1, area);

                    break;

                case Direction.Right:
                    if (originalXCoordinate < area.AreaGrid.Length)
                        if (CheckIfNextCellIsPassable(nextXCoordinate + 1, nextYCoordinate, area))
                            nextXCoordinate++;
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate + 1, nextYCoordinate, area);
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
                    if(cellObject.EventTriggers != null)
                        if(cellObject.EventTriggers.Count > 0)
                        {
                            foreach(KeyValuePair<double, Action> gameEvent in cellObject.EventTriggers)
                            {
                                if (gameEvent.Key > HelperMethods.GetRandomNumber(0, 1))
                                {
                                    gameEvent.Value.Invoke();
                                }
                            }
                        }
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
