using GameEngine.Events;
using GameEngine.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.System;

namespace GameEngine.GameBoard
{
	public static class Movement
	{
        public static void MoveCellObject(ICellObject cellObject, Area area, VirtualKey direction)
		{
            var originalXCoordinate = cellObject.Position.x;
            var originalYCoordinate = cellObject.Position.y;

            var nextXCoordinate = originalXCoordinate;
            var nextYCoordinate = originalYCoordinate;

            switch (direction)
            {
                case VirtualKey.Left:
                    if (originalXCoordinate > 1)
                        if (CheckIfNextCellIsPassable(nextXCoordinate - 1, nextYCoordinate, area))
                            nextXCoordinate--;
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate - 1, nextYCoordinate, area, GameEvent.EventTypes.Collision);

                    break;

                case VirtualKey.Up:
                    if (originalYCoordinate > 1) 
                        if (CheckIfNextCellIsPassable(nextXCoordinate, nextYCoordinate - 1, area))
                            nextYCoordinate--;
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate - 1, area, GameEvent.EventTypes.Collision);

                    break;

                case VirtualKey.Down:
                    if (originalYCoordinate < area.AreaGrid[0].Length)
                        if (CheckIfNextCellIsPassable(nextXCoordinate, nextYCoordinate + 1, area))
                            nextYCoordinate++;
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate + 1, area, GameEvent.EventTypes.Collision);

                    break;

                case VirtualKey.Right:
                    if (originalXCoordinate < area.AreaGrid.Length)
                        if (CheckIfNextCellIsPassable(nextXCoordinate + 1, nextYCoordinate, area))
                            nextXCoordinate++;
                        else TriggerEventHandlerInNextCellObject(nextXCoordinate + 1, nextYCoordinate, area, GameEvent.EventTypes.Collision);
                    break;

                default: return;
            }

            area.AreaGrid[originalXCoordinate - 1][originalYCoordinate - 1].CellObjects.Remove(cellObject);
            area.AreaGrid[nextXCoordinate - 1][nextYCoordinate - 1].CellObjects.Add(cellObject);
            cellObject.Position = (nextXCoordinate, nextYCoordinate);

            TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate, area, GameEvent.EventTypes.Enter);
        }

        private static void TriggerEventHandlerInNextCellObject(int xPos, int yPos, Area area, GameEvent.EventTypes eventType)
        {
            var cellObjects = area.AreaGrid[xPos - 1][yPos - 1].CellObjects;
            if(cellObjects.Count > 0)
            {
                foreach (var cellObject in cellObjects)
                {
                    if(cellObject.EventTriggers != null)
                        if(cellObject.EventTriggers.Count > 0)
                        {
                            foreach(var gameEvent in cellObject.EventTriggers)
                            {
                                if (gameEvent.TriggerChance > HelperMethods.GetRandomNumber(0, 1) && gameEvent.EventType == eventType)
                                {
                                    gameEvent.EventAction.Invoke();
                                }
                            }
                        }
                }
            }
        }

        private static bool CheckIfNextCellIsPassable(int xPos, int yPos, Area area)
        {
            if (xPos == 0 || yPos == 0 || xPos == area.AreaGrid.Length+1 || yPos == area.AreaGrid[0].Length+1)
                return true;

            var cellObjects = area.AreaGrid[xPos - 1][yPos - 1].CellObjects;

            //TriggerEventHandlerInNextCellObject(xPos, yPos, area);

            return cellObjects.All(cellObject => cellObject.IsPassable);
        }

        public static void InteractWithCellObject(ICellObject cellObject, Area area)
        {
            int xPos = cellObject.Position.x;
            int yPos = cellObject.Position.y;

            if (!CheckIfNextCellIsPassable(xPos - 1, yPos, area))
                TriggerEventHandlerInNextCellObject(xPos - 1, yPos, area, GameEvent.EventTypes.Interaction);

            if (!CheckIfNextCellIsPassable(xPos + 1, yPos, area))
                TriggerEventHandlerInNextCellObject(xPos+1,yPos,area, GameEvent.EventTypes.Interaction);

            if (!CheckIfNextCellIsPassable(xPos, yPos - 1, area))
                TriggerEventHandlerInNextCellObject(xPos,yPos-1,area, GameEvent.EventTypes.Interaction);

            if (!CheckIfNextCellIsPassable(xPos, yPos + 1, area))
                TriggerEventHandlerInNextCellObject(xPos,yPos+1,area, GameEvent.EventTypes.Interaction);
        }

        public static void HandleInput(VirtualKey eVirtualKey, ICellObject cellObject)
        {
            if(IsDirectional(eVirtualKey))
                MoveCellObject(cellObject, Game.GetInstance().CurrentArea, eVirtualKey);
            else
                InteractWithCellObject(cellObject, Game.GetInstance().CurrentArea);
        }

        private static bool IsDirectional(VirtualKey eVirtualKey)
        {
            if (eVirtualKey == VirtualKey.Left
                || eVirtualKey == VirtualKey.Right
                || eVirtualKey == VirtualKey.Up
                || eVirtualKey == VirtualKey.Down)
                return true;

            return false;
        }
    }
}
