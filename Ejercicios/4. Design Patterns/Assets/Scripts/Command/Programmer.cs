using UnityEngine;
using System.Collections.Generic;

namespace Patterns
{
	public class Programmer : MonoBehaviour {

		private Queue<IAction> actions;

		[SerializeField]
		private CommandedCharacter character;

		private void Awake ()
		{
			actions = new Queue<IAction> ();
		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space))
				ExecuteNextActions ();
			else if (Input.GetKeyDown (KeyCode.A))
				actions.Enqueue (new Attack ());
			else if (Input.GetKeyDown (KeyCode.M)) {
				int x = Random.Range (0, 10);
				int y = Random.Range (0, 10);
				actions.Enqueue (new Move (x, y));
			}
		}

		private void ExecuteNextActions ()
		{
			if (actions.Count == 0) return;
			IAction action = actions.Dequeue ();
			action.Execute (character);
		}
	}
}