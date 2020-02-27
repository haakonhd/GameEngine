﻿using GameEngine.GameObjects;
using GameEngineRuntimeComponent.Events;
using System.Collections.Generic;

namespace GameEngine
{
    public interface ICellObject 
    {
        Sprite Sprite { get; set; }
        bool IsPassable { get; set; }
        string Key { get; set; }
        List<IGameEvent> EventTriggers { get; set; }
        (int x, int y) Position { get; set; }
    }
}