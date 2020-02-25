using GameEngine.Implementation.Pokemon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        public MainPage()
        {
            this.InitializeComponent();

            //For some weird reason the view isnt available after initialization, so we need to wait for it to become available
            //TODO: find another workaround for this

            // Couldn't find a way to run this uwp project from another project. To simulate the relationship between
            // the game engine and an game implementation, this implementation project will exist in a folder in this project.
            // This class will start up the project that the user wants to run, which will again call to GameWindow. 
            Loaded += async (s, e) =>
            {
                await Task.Delay(100);
                Frame.Navigate(typeof(GameInitializer));
            };
        }
    }
}
