using GameEngine.GameObjects;
using GameEngineRuntimeComponent.Events;
using System.Collections.Generic;
using static GameEngine.Factories.CellObjectFactory;

namespace GameEngine
{
    public interface ICellObject 
    {
        Sprite Sprite { get; set; }
        bool IsPassable { get; set; }
        CellObjectType EnumType { get; set; }
        List<IGameEvent> EventTriggers { get; set; }
        (int x, int y) Position { get; set; }
    }
}