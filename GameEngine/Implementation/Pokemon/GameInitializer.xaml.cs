using GameEngine.Factories;
using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using static GameEngine.Factories.CellObjectFactory;
using static GameEngine.Implementation.Pokemon.Factories.BattleAttackFactory;
using static GameEngine.Implementation.Pokemon.Factories.InventoryItemFactory;

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

            Game pokemon = new Game()
            {
                Title = "Pokémon",
                GameWidth = 600
            };

            Area palletTown = new Area();
            palletTown.SetAreaGrid(10, 7);
            palletTown.BackgroundCellObject = CellObjectFactory.Build(CellObjectType.Grass);

            pokemon.Areas.Add(palletTown);
            pokemon.CurrentArea = palletTown;

            IPlayableCharacter red = ((IPlayableCharacter)CellObjectFactory.Build(CellObjectType.Hero));
     
            red.BattleAttacks.Add(BattleAttackFactory.Build(AttackName.Stab));
            red.ItemInventory.Add(InventoryItemFactory.Build(ItemName.SmallHealthPotion));

            pokemon.PlayableCharacter = red;

            ICellObject npc = CellObjectFactory.Build(CellObjectType.Npc);
            ICellObject enemy = CellObjectFactory.Build(CellObjectType.Enemy);

            palletTown.SetCellObjectGridPosition(3, 5, red);
            palletTown.SetCellObjectGridPosition(5, 2, npc);
            palletTown.SetCellObjectGridPosition(1, 2, enemy);
            palletTown.AreaMusic = new MediaHandler("shake.mp3");

            pokemon.CurrentArea = palletTown;
            pokemon.CurrentlyPlayingMusic = palletTown.AreaMusic;

            //For some weird reason the view isn't available after initialization, 
            // so we need to wait for it to become available
            //TODO: find another workaround for this
            Loaded += async (s, e) =>
            {
                await Task.Delay(100);
                Frame.Navigate(typeof(GameWindow), pokemon);
            };
        }
	}
}
