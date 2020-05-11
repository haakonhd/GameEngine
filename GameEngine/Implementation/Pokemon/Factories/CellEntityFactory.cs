using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine.Implementation.Pokemon.Factories
{
    /// <summary>
    /// Gives access to all cell entities in the game
    /// </summary>
    public static class CellEntityFactory
    {
        public enum entityType
        {
            ChatBubble,
            MessageBox
        }

        public static ICellEntity Build(entityType entityName)
        {
            switch(entityName)
            {
                case entityType.ChatBubble:
                    return new ChatBubble();

                case entityType.MessageBox:
                    return new MessageBox();

                default:
                    return null;
            }
        }
    }
}
