using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Areas;
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

            Game pokemon = Game.Instance;

            pokemon.Title = "Pokémon";
            pokemon.GameWidth = 800;
            pokemon.GamePathName = "Pokemon";

            Area newBarkTown = NewBarkTown.Instance.Area;

            pokemon.Areas.Add(newBarkTown);
            pokemon.Areas.Add(RouteOne.Instance.Area);
            pokemon.CurrentArea = newBarkTown;
            pokemon.NextArea = newBarkTown;


            IPlayableCharacter red = ((IPlayableCharacter)CellObjectFactory.Build(CellObjectType.Hero));
     
            red.BattleAttacks.Add(BattleAttackFactory.Build(AttackName.Stab));
            red.ItemInventory.Add(InventoryItemFactory.Build(ItemName.SmallHealthPotion));

            pokemon.PlayableCharacter = red;
            red.Position = (10, 8);
            //newBarkTown.SetCellObjectGridPosition(10, 8, red);

            //pokemon.CurrentArea = newBarkTown;

            //pokemon.InitializeGame = InitializeGame;

            InitializeGameFirstTime();
        }

        public void InitializeGameFirstTime()
        {
            var game = Game.Instance;
            game.CurrentArea.SetCellObjectGridPosition(game.PlayableCharacter.Position.x, game.PlayableCharacter.Position.y, game.PlayableCharacter);
            //For some weird reason the view isn't available right after initialization, 
            // so we need to wait for it to become available
            //TODO: find another workaround for this
            Loaded += async (s, e) =>
            {
                await Task.Delay(100);
                Frame.Navigate(typeof(GameWindow), game);
            };
        }

        public void InitializeGame()
        {
            GameWindow.renderIsInProgress = true;
            var game = Game.Instance;
            //game.CurrentArea.SetCellObjectGridPosition(game.PlayableCharacter.Position.x, game.PlayableCharacter.Position.y, game.PlayableCharacter);
            Frame.Navigate(typeof(GameWindow), game);
        }
    }
}
