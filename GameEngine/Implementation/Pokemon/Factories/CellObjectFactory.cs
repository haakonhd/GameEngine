using GameEngine.GameObjects;
using GameEngine.Implementation.Pokemon.Areas;
using GameEngine.Implementation.Pokemon.FactoryObjects;
using GameEngine.Implementation.Pokemon.FactoryObjects.Inanimate_objects;
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
			Merchant,
			Sign,
			Rug,
			Bookshelf,
			Flower,
			FancyHouse,
			LabThing,
			Floor
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
				case CellObjectType.Sign:
					return new Sign("This is a custom view. Touch the sign again to close this message.");
				case CellObjectType.Rug:
					return new Rug();
				case CellObjectType.Bookshelf:
					return new Bookshelf();
				case CellObjectType.Flower:
					return new Flower();
				case CellObjectType.FancyHouse:
					return new FancyHouse();
				case CellObjectType.LabThing:
					return new LabThing();
				case CellObjectType.Floor:
					return new Floor();
				//TODO: make default throw exception
				default:
					return null;
			}
		}
	}
}
