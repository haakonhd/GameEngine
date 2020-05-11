using GameEngine.Events;
using GameEngine.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.System;

namespace GameEngine.GameBoard
{
    /// <summary>
    /// A class used to manage movement of the player
    /// </summary>
	public static class Movement
	{
        /// <summary>
        /// A function used to move a character in different directions based on user input
        /// </summary>
        /// <param name="cellObject">The object that is supposed to be moved</param>
        /// <param name="area">What area the object is in</param>
        /// <param name="direction">Keyboard input that determines the direction to move</param>
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

            // cellobject has moved
            if(nextXCoordinate != originalXCoordinate || nextYCoordinate != originalYCoordinate)
            {
                
            }

            area.AreaGrid[originalXCoordinate - 1][originalYCoordinate - 1].CellObjects?.Remove(cellObject);
            area.AreaGrid[nextXCoordinate - 1][nextYCoordinate - 1].CellObjects.Add(cellObject);
            cellObject.Position = (nextXCoordinate, nextYCoordinate);

            TriggerEventHandlerInNextCellObject(nextXCoordinate, nextYCoordinate, area, GameEvent.EventTypes.Enter);
        }

        /// <summary>
        /// A function to trigger the events in the next cell
        /// </summary>
        /// <param name="xPos">X position of the cell</param>
        /// <param name="yPos">Y position of the cell</param>
        /// <param name="area">What area the cell is in</param>
        /// <param name="eventType">What kind of event type it's going to trigger</param>
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

        /// <summary>
        /// Checks if the next cell the character is attempting to move into is enterable
        /// </summary>
        /// <param name="xPos">X position of the tested cell</param>
        /// <param name="yPos">Y position of the tested cell</param>
        /// <param name="area">The area the cell is in</param>
        /// <returns></returns>
        private static bool CheckIfNextCellIsPassable(int xPos, int yPos, Area area)
        {
            if (xPos == 0 || yPos == 0 || xPos == area.AreaGrid.Length+1 || yPos == area.AreaGrid[0].Length+1)
                return true;

            var cellObjects = area.AreaGrid[xPos - 1][yPos - 1]?.CellObjects;

            //TriggerEventHandlerInNextCellObject(xPos, yPos, area);

            return cellObjects.All(cellObject => cellObject.IsPassable);
        }

        /// <summary>
        /// A function to try to interact with the cells around the player
        /// </summary>
        /// <param name="cellObject">The object that you control</param>
        /// <param name="area">The area the object is in</param>
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

        /// <summary>
        /// A function that will handle the input of the player and use it accordingly
        /// </summary>
        /// <param name="eVirtualKey">Keybaord input</param>
        /// <param name="cellObject">The object that the player controls</param>
        public static void HandleInput(VirtualKey eVirtualKey, ICellObject cellObject)
        {
            switch (Game.Instance.CurrentGameState)
            {
                case Game.GameState.Movement:
                    if(IsDirectional(eVirtualKey))
                        MoveCellObject(cellObject, Game.Instance.CurrentArea, eVirtualKey);
                    else
                        InteractWithCellObject(cellObject, Game.Instance.CurrentArea);
                    break;

                case Game.GameState.Dialog:
                    //TODO add dialog controls
                    break;

                case Game.GameState.Combat:
                    //TODO Add combat controls
                    break;

                case Game.GameState.Menu:
                    //TODO add menu controls
                    break;

            }
        }

        /// <summary>
        /// A function to check if the keyboard input is directional
        /// </summary>
        /// <param name="eVirtualKey">Keyboard input</param>
        /// <returns></returns>
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
