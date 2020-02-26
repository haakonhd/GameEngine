using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Factories
{
	public static class CellObjectFactory
	{
		public static ICellObject Build(string cellObjectType)
		{
			switch (cellObjectType)
			{
				case "HERO":
					return new Hero();
				case "GRASS":
					return new Grass();
				case "NPC":
					return new Npc();
				//TODO: make default throw exception
				default:
					return null;
			}
		}
	}
}
