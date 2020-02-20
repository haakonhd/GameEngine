using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Parameters;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
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
            InitializeComponent();

            Game pokemon = new Game();
            Area palletTown = new Area();
            palletTown.SetAreaGrid(10, 7);
            pokemon.Areas.Add(palletTown);
            Hero red = new Hero(new Sprite("hero.png"), 10);
            palletTown.PlaceObjectToGrid(3, 5, red);
            pokemon.StartArea = palletTown;
            palletTown.AreaMusic = new MediaHandler("shake.mp3");
            pokemon.CurrentlyPlayingMusic = palletTown.AreaMusic;

            //For some weird reason the view isnt available after initialization, so we need to wait for it to become available
            //TODO: find another workaround for this
            Loaded += async (s, e) =>
            {
                await Task.Delay(100);
                StartGameParams startGameParams = new StartGameParams(palletTown, 400, 400);
                Frame.Navigate(typeof(VisualGameBoard), startGameParams);
            };

            //this.Frame.Navigate(typeof(VisualGameBoard));
        }
    }
}
