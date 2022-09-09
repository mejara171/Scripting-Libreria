using UnityEngine;
using System.Collections;

namespace Patterns
{
	public interface IAction {

		void Execute (CommandedCharacter character);
	}
}