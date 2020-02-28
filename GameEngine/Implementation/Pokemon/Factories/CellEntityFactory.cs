using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine.Implementation.Pokemon.Factories
{
    static class CellEntityFactory
    {
        public enum EntityTypes
        {
            Speech,
            MessageBox
        }
        public static ICellEntity Build(EntityTypes entityName)
        {
            switch (entityName)
            {
                case EntityTypes.Speech:
                    return new ChatBubble();

                case EntityTypes.MessageBox:
                    return new MessageBox();

                default: return null;
            }
        }
    }
}
