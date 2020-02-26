using GameEngine.Factories;
using GameEngine.GameBoard;
using GameEngine.GameObjects;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameEngine.Implementation.Pokemon
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class GameInitializer : Page
	{
		public GameInitializer()
		{
			this.InitializeComponent();

            Game pokemon = new Game();
            pokemon.Title = "Pokémon";
            pokemon.GameWidth = 600;
            Area palletTown = new Area();
            palletTown.SetAreaGrid(10, 7);
            palletTown.BackgroundCellObject = CellObjectFactory.Build("GRASS");
            pokemon.Areas.Add(palletTown);
            pokemon.CurrentArea = palletTown;
            PlayableCharacter red = new PlayableCharacter(CellObjectFactory.Build("HERO"));
            ICellObject npc = CellObjectFactory.Build("NPC");
            palletTown.SetCellObjectGridPosition(3, 5, red.CellObject);
            palletTown.SetCellObjectGridPosition(7, 2, npc);
            pokemon.CurrentArea = palletTown;
            palletTown.AreaMusic = new MediaHandler("shake.mp3");
            pokemon.CurrentlyPlayingMusic = palletTown.AreaMusic;

            //For some weird reason the view isnt available after initialization, so we need to wait for it to become available
            //TODO: find another workaround for this
            Loaded += async (s, e) =>
            {
                await Task.Delay(100);
                Frame.Navigate(typeof(GameWindow), pokemon);
            };
        }
	}
}
