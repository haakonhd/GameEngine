using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects.People;

namespace GameEngine.Implementation.Pokemon.Factories
{
	public static class CellObjectFactory
	{
		public enum CellObjectType
		{
			Hero,
			Grass,
			Npc,
			Enemy,
			SmallHouse,
			MediumHouse,
			BigHouse,
			Tree,
			Merchant
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
				case CellObjectType.SmallHouse:
					return new SmallHouse();
				case CellObjectType.MediumHouse:
					return new MediumHouse();
				case CellObjectType.BigHouse:
					return new BigHouse();
				case CellObjectType.Tree:
					return new Tree();
				case CellObjectType.Merchant:
					return new Merchant();
				//TODO: make default throw exception
				default:
					return null;
			}
		}
	}
}
