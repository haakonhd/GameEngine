using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Factories;
using GameEngine.Implementation.Pokemon.FactoryObjects;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using static GameEngine.Implementation.Pokemon.Factories.BattleAttackFactory;
using static GameEngine.Implementation.Pokemon.Factories.CellObjectFactory;
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
			InitializeComponent();

            Game pokemon = Game.GetInstance();

            pokemon.Title = "Pokémon";
            pokemon.GameWidth = 800;
            pokemon.GamePathName = "Pokemon";

            Area palletTown = new Area();
            palletTown.SetAreaGrid(20, 14);
            palletTown.BackgroundCellObject = CellObjectFactory.Build(CellObjectType.Grass);

            pokemon.Areas.Add(palletTown);
            pokemon.CurrentArea = palletTown;

            IPlayableCharacter red = ((IPlayableCharacter)CellObjectFactory.Build(CellObjectType.Hero));
     
            red.BattleAttacks.Add(BattleAttackFactory.Build(AttackName.Stab));
            red.ItemInventory.Add(InventoryItemFactory.Build(ItemName.SmallHealthPotion));

            pokemon.PlayableCharacter = red;

            ICellObject npc = CellObjectFactory.Build(CellObjectType.Npc);
            ICellObject enemy = CellObjectFactory.Build(CellObjectType.Enemy);
            ICellObject smallHouse = CellObjectFactory.Build(CellObjectType.SmallHouse);
            ICellObject mediumHouse = CellObjectFactory.Build(CellObjectType.MediumHouse);
            ICellObject bigHouse = CellObjectFactory.Build(CellObjectType.BigHouse);
            ICellObject tree = CellObjectFactory.Build(CellObjectType.Tree);
            
            palletTown.SetCellObjectGridPosition(3, 5, red);
            palletTown.SetCellObjectGridPosition(7, 5, npc);
            palletTown.SetCellObjectGridPosition(1, 4, enemy);
            palletTown.SetCellObjectGridPosition(4, 10, smallHouse);
            palletTown.SetCellObjectGridPosition(14, 2, mediumHouse);
            palletTown.SetCellObjectGridPosition(6, 1, bigHouse);
            palletTown.SetCellObjectGridPosition(1, 1, tree);
            palletTown.SetCellObjectGridPosition(2, 1, tree);
            palletTown.SetCellObjectGridPosition(3, 1, tree);
            palletTown.AreaMusic = new MediaHandler("shake.mp3");

            pokemon.CurrentArea = palletTown;
            pokemon.CurrentlyPlayingMusic = palletTown.AreaMusic;
            //pokemon.CurrentlyPlayingMusic.SoundPlayer.Play();


            //For some weird reason the view isn't available right after initialization, 
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
