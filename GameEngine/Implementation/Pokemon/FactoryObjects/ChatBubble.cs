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
            EntityLifetime = Game.Instance.StopWatch.ElapsedMilliseconds + duration;
            VoiceLines = text;
        }

        public ChatBubble()
        {
            
        }

        public void InitializeDialog()
        {
            Game.Instance.CurrentGameState = Game.GameState.Dialog;
        }
    }
}
