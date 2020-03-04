using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;

namespace GameEngine.Implementation.Pokemon.Factories
{
	public static class CellObjectFactory
	{
		public enum CellObjectType
		{
			Hero,
			Grass,
			Npc,
			Enemy
		}

		public static ICellObject Build(CellObjectType cellObjectType)
		{
			switch (cellObjectType)
			{
				case CellObjectType.Hero:
					return new Hero();
				case CellObjectType.Grass:
					return new Grass();
				case CellObjectType.Npc:
					return new Npc();
				case CellObjectType.Enemy:
					return new Enemy();
				//TODO: make default throw exception
				default:
					return null;
			}
		}
	}
}
