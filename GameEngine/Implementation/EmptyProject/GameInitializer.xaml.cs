using GameEngine.GameBoard;
using GameEngine.GameObjects;
using GameEngine.Implementation.EmptyProject.Areas;
using GameEngine.Implementation.EmptyProject.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameEngine.Implementation.EmptyProject
{
	/// <summary>
	/// The page where a game is initialized
	/// </summary>
	public sealed partial class GameInitializer : Page
	{
		public GameInitializer()
		{
			InitializeComponent();

			Game newGame = Game.Instance;
			newGame.Title = "Name your game here";
			//Set total width of the game window in pixels
			newGame.GameWidth = 800;
			//Set this property to be the name of the game in your file structure
			newGame.GamePathName = "Pokemon";

			// Create a singleton object in the areas folder and instanciate it here
			Area firstArea = FirstArea.Instance.Area;

			// Add the area to the game
			newGame.Areas.Add(firstArea);
			//Set firstArea to be the starting area when you run the game
			newGame.CurrentArea = firstArea;
			//Change this to travel to a new area
			newGame.NextArea = firstArea;

			//Use a cell object factory to create a playable character to be used in the game
			IPlayableCharacter hero = (IPlayableCharacter)CellObjectFactory.Build(CellObjectFactory.CellObjectType.Hero);

			//From the battle attack factory, give your hero an attack to be used in battle
			hero.BattleAttacks.Add(BattleAttackFactory.Build(BattleAttackFactory.AttackName.Stab));
			//From the inventory item factory, give your hero an item to keep in their inventory
			hero.ItemInventory.Add(InventoryItemFactory.Build(InventoryItemFactory.ItemName.SmallHealthPotion));

			//Set your hero to be the playable character of the game
			newGame.PlayableCharacter = hero;
			//Set the start position of the character in the game
			hero.Position = (6,6);
			//Start game
			InitializeGame();
		}

		/// <summary>
		/// Navigates to the game window where the game is run
		/// </summary>
		public void InitializeGame()
		{
			var game = Game.Instance;
			game.CurrentArea.SetCellObjectGridPosition(game.PlayableCharacter.Position.x, game.PlayableCharacter.Position.y, game.PlayableCharacter);
			// The view isn't available immediately after initialization, so we need to wait for it to become available
			Loaded += async (s, e) =>
			{
				await Task.Delay(100);
				Frame.Navigate(typeof(GameWindow), game);
			};
		}
	}
}
