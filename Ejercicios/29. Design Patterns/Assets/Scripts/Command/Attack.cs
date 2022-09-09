using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class Attack: IAction{

		public void Execute (CommandedCharacter character)
		{
			character.Attack ();
		}
	}
}