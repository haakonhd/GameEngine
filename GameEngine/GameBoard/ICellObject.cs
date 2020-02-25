using GameEngine.GameObjects;
using GameEngineRuntimeComponent.Events;
using System;
using System.Collections.Generic;

namespace GameEngine
{
    public interface ICellObject 
    {
        Sprite Sprite { get; set; }
        bool IsPassable { get; set; }
        string Key { get; set; }
        List<IEvent> EventTriggers { get; set; }
    }
}