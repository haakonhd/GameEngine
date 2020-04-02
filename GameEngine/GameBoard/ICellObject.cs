using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;

namespace GameEngine
{
    public interface ICellObject 
    {
        Sprite Sprite { get; set; }
        bool IsPassable { get; set; }
        List<GameEvent> EventTriggers { get; set; }
        (int x, int y) Position { get; set; }
        ICellObject GetCopy();
    }
}