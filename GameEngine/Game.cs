﻿using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Game
    {

        public enum GameState
        {
            Movement,
            Dialog,
            Combat,
            Menu
        }

        public GameState CurrentGameState;
        internal MediaHandler CurrentlyPlayingMusic { get; set; }
        public string Title { get; set; }
        public string GamePathName { get; set; }
        public List<Area> Areas{ get; }
		public Area CurrentArea { get; set; }
        public int GameWidth { get; set; }
        public IPlayableCharacter PlayableCharacter { get; set; }
        public Stopwatch StopWatch = new Stopwatch();
        public Battle OngoingBattle { get; set; }
        private static Game instance = null;
        private static readonly object padlock = new object();
        public Action Reload { get; set; }

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

        public void ChangeGameState(GameState state)
        {
            CurrentGameState = state;
        }
    }
}