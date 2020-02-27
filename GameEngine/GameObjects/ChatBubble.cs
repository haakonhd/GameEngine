using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Maps.Guidance;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using GameEngine.GameBoard;

namespace GameEngine.GameObjects
{
    class ChatBubble : ICellEntity
    {
        public object Entity { get; set; }
        public (int x, int y) Position { get; set; }
        public long EntityLifetime { get; set; }

        public ChatBubble(Game game, int duration, string text, int xPos, int yPos)
        {
            EntityLifetime = game.stopWatch.ElapsedMilliseconds + duration;
            Position = (xPos, yPos);
            TextBox txtBox = new TextBox();
            txtBox.Text = text;
            
            int cellSize = game.GameWidth / game.CurrentArea.Width;

            txtBox.Width = cellSize;
            txtBox.Height = cellSize;
            txtBox.SetValue(Grid.ColumnProperty, xPos);
            txtBox.SetValue(Grid.RowProperty, yPos);
            txtBox.Background = new SolidColorBrush(color: Colors.Black);
            txtBox.Background.Opacity = 0;
            txtBox.BorderBrush = new SolidColorBrush(Color.FromArgb(0,0,0,255));

            Entity = txtBox;
        }
    }
}
