using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GameEngine.GameBoard;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace GameEngine
{
    public class Game
    {
        /// <summary>
        /// Represents a state the game can be in
        /// </summary>
        public enum GameState
        {
            /// <summary>
            /// Normal game mode
            /// </summary>
            Movement,
            /// <summary>
            /// A dialog is showing
            /// </summary>
            Dialog,
            /// <summary>
            /// The player is in a battle
            /// </summary>
            Combat,
            /// <summary>
            /// The menu is showing
            /// </summary>
            Menu
        }
        /// <summary>
        /// Keep track of what is happening in the game
        /// </summary>
        public GameState CurrentGameState;
        /// <summary>
        /// The music being played right now
        /// </summary>
        internal MediaHandler CurrentlyPlayingMusic { get; set; }
        /// <summary>
        /// The title of the game
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The folder name of the game inside the "implementation" folder
        /// </summary>
        public string GamePathName { get; set; }
        /// <summary>
        /// List of all areas of the game
        /// </summary>
        public List<Area> Areas { get; }
        /// <summary>
        /// The area that is currently active
        /// </summary>
		public Area CurrentArea { get; set; }
        /// <summary>
        /// Represents the area the player is traveling to
        /// </summary>
        public Area NextArea { get; set; }
        /// <summary>
        /// Total width of the game window in pixels
        /// </summary>
        public int GameWidth { get; set; }
        /// <summary>
        /// The playable character of the game
        /// </summary>
        public IPlayableCharacter PlayableCharacter { get; set; }
        /// <summary>
        /// Used for timing game events
        /// </summary>
        public Stopwatch StopWatch = new Stopwatch();
        /// <summary>
        /// The current battle in progress
        /// </summary>
        public Battle OngoingBattle { get; set; }
        private static Game instance = null;
        private static readonly object padlock = new object();
        /// <summary>
        /// Items added to this list will be shown in the game window
        /// </summary>
        public List<UIElement> CustomUIElementsToBeAdded { get; set; } = new List<UIElement>();
        /// <summary>
        /// Keeps track of all custom UI elements on the screen
        /// </summary>
        public List<UIElement> CustomUIElementsInView { get; set; } = new List<UIElement>();
        /// <summary>
        /// Items added here will be removed from the game screen
        /// </summary>
        public List<UIElement> CustomUIElementsToBeDeleted { get; set; } = new List<UIElement>();

        /// <summary>
        /// Singleton instance of the game
        /// </summary>
        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Game();
                        }
                    }
                }
                return instance;
            }
        }

        public Game()
        {
            Areas = new List<Area>();
        }

        /// <summary>
        /// Changes the game state
        /// </summary>
        /// <param name="state"></param>
        public void ChangeGameState(GameState state)
        {
            CurrentGameState = state;
            //TODO implement logic for when different states are initialized
        }
    }
}