using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Events
{
	public class Battle
	{
		public IFighter Hero { get; set; }
		public IFighter Enemy { get; set; }
		public Battle(IFighter hero)
		{
			Hero = hero;
		}

		public void StartBattle()
		{
			//TODO: handle error
			if (Hero == null || Enemy == null) return;
			//TODO: create battle
		}

        public void EndBattle()
        {
			//TODO Add logic
        }
	}
}
