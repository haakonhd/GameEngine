using GameEngine.GameBoard;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameEngine.Events
{
	public class Battle
	{
		public IFighter Hero { get; set; }
		public IFighter Enemy { get; set; }
        private static Battle instance = null;
        private static readonly object padlock = new object();

        public Battle()
        {
        }

        public static Battle Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Battle();
                        }
                    }
                }
                return instance;
            }
        }

        public void StartBattle()
		{
            Hero = Game.Instance.PlayableCharacter;
            //TODO: handle error: no enemy set
            if (Enemy == null)
                return;

            GameWindow.GameWindowFrame?.Navigate(typeof(BattleWindow));
        }

        public void EndBattle()
        {
        }
	}
}
