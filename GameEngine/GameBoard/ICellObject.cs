using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;

namespace GameEngine
{
    //TODO: set cell span properties
    public interface ICellObject 
    {
        Sprite Sprite { get; set; }
        bool IsPassable { get; set; }
        // Action that will trigger when the player steps or try to step on this cell
        // double: chance for event to trigger. Example: 0.75 means a 75% chance
        Dictionary<double, Action> EventTriggers { get; set; }
        (int x, int y) Position { get; set; }
        int CellWidth { get; set; }
        int CellHeight { get; set; }
        ICellObject GetCopy();
    }
}