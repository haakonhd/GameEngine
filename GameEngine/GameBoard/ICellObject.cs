using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;

namespace GameEngine
{
    //TODO: set cell span properties
    /// <summary>
    /// An object to be placed on the game board
    /// </summary>
    public interface ICellObject 
    {
        /// <summary>
        /// The picture that will be shown on the game board
        /// </summary>
        Sprite Sprite { get; set; }
        /// <summary>
        /// If false, the player will not be able to walk on 
        /// </summary>
        bool IsPassable { get; set; }
        /// <summary>
        /// If the playable character steps on/collides/interacts with this ibject, one or more event might be triggered
        /// </summary>
        List<GameEvent> EventTriggers { get; set; }
        /// <summary>
        /// X and Y grid position of the object 
        /// </summary>
        (int x, int y) Position { get; set; }
        /// <summary>
        /// How many cells the object should span over
        /// </summary>
        int CellWidth { get; set; }
        /// <summary>
        /// How many cells the object should span over
        /// </summary>
        int CellHeight { get; set; }
        /// <summary>
        /// For the rendering to work, a function to set the sprite is needed
        /// </summary>
        void SetSprite();
    }
}