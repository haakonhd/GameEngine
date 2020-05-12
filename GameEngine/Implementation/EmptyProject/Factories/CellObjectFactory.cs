using GameEngine.Implementation.EmptyProject.FactoryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementation.EmptyProject.Factories
{
	/// <summary>
	/// Gives access to all the game's cell objects
	/// </summary>
	class CellObjectFactory
	{
		// Whenever you add a new game object, add them here and in the switch below
		public enum CellObjectType
		{
			Hero,
			Grass,
			Tree,
			Sign
		}

		/// <summary>
		/// Retrieve an instance of cell object from selected enum
		/// </summary>
		/// <param name="cellObjectType"></param>
		/// <returns></returns>
		public static ICellObject Build(CellObjectType cellObjectType)
		{
			switch (cellObjectType)
			{
				case CellObjectType.Hero:
					return new Hero();
				case CellObjectType.Grass:
					return new Grass();
				case CellObjectType.Tree:
					return new Tree();
				case CellObjectType.Sign:
					return new Sign("This is a custom view. Touch the sign again to remove this message");
				default:
					return null;
			}
		}

		internal static ICellObject Build(Pokemon.Factories.CellObjectFactory.CellObjectType grass)
		{
			throw new NotImplementedException();
		}
	}
}
