namespace Patterns
{
	public class Move: IAction {

		private int x, y;

		public Move (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public void Execute (CommandedCharacter charater)
		{
			charater.Move (x, y);
		}
	}
}