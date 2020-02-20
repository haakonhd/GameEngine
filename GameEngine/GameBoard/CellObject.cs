using GameEngine.GameObjects;

namespace GameEngine
{
    public abstract class CellObject
    {
        public Sprite Sprite { get; set; }
        public bool IsPassable { get; set; }
    }
}