using System.Collections.Generic;

namespace GameEngine.GameObjects
{
	/// <summary>
	/// Represents the character the player can control in the game
	/// </summary>
	public interface IPlayableCharacter : ICellObject, IFighter
	{
		/// <summary>
		/// Money that can be used buying items
		/// </summary>
		int PlayerMoney { get; set; }
	}
}
