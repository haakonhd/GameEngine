using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using GameEngine.GameBoard;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
    class ChatBubble : ICellEntity
    {
        public object Entity { get; set; }
        public (int x, int y) Position { get; set; }
        public long EntityLifetime { get; set; }
        public string VoiceLines { get; set; }

        public ChatBubble(int duration, string text)
        {
            EntityLifetime = Game.StopWatch.ElapsedMilliseconds + duration;
            VoiceLines = text;
        }

        public ChatBubble()
        {
            
        }
    }
}
