using GameEngine.GameBoard;
using GameEngine.GameObjects;

namespace GameEngine.Implementation.Pokemon.Factories
{
    static class CellEntityFactory
    {
        public enum EntityTypes
        {
            Speech
        }
        public static ICellEntity Build(EntityTypes entityName)
        {
            switch (entityName)
            {
                case EntityTypes.Speech:
                    return new ChatBubble();

                default: return null;
            }
        }
    }
}
