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

        public ChatBubble(int duration, string text, int xPos, int yPos)
        {
            EntityLifetime = Game.StopWatch.ElapsedMilliseconds + duration;
            Position = (xPos, yPos);
            TextBox txtBox = new TextBox();
            txtBox.Text = text;
            
            txtBox.SetValue(Grid.ColumnProperty, xPos);
            txtBox.SetValue(Grid.RowProperty, yPos);
            txtBox.Background = new SolidColorBrush(color: Colors.Black);
            txtBox.Background.Opacity = 0;
            txtBox.BorderBrush = new SolidColorBrush(Color.FromArgb(0,0,0,255));

            Entity = txtBox;
        }

        public ChatBubble()
        {
            
        }
    }
}
