

namespace GameEngine.GameObjects
{
	public class PlayableCharacter
	{
		public ICellObject CellObject { get; set; }
		public PlayableCharacter(ICellObject cellObject)
		{
			CellObject = cellObject;
		}

	}
}
