using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameEngine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Music song;
        private bool isPlaying;

        public MainPage()
        {
            InitializeComponent();
            btn.Content = "Shake it";
            song = new Music();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isPlaying)
            {
                song.PlayMusic();
                btn.Content = "Stop shaking";
                isPlaying = true;
            }
            else
            {
                song.PauseMusic();
                btn.Content = "Shake it";
                isPlaying = false;
            }
        }

    }
}
