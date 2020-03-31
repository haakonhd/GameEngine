using GameEngine.Events;
using GameEngine.GameObjects;
using System.Collections.Generic;

namespace GameEngine
{
    public interface ICellObject 
    {
        Sprite Sprite { get; set; }
        bool IsPassable { get; set; }
        Dictionary<IGameEvent, double> EventTriggers { get; set; }
        (int x, int y) Position { get; set; }
        ICellObject GetCopy();
    }
}