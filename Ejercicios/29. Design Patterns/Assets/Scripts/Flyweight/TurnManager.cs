using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
	public class TurnManager : MonoBehaviour
	{
		public Soldier[] soldiers;
		private int current;

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space))
				Next ();
		}

		private void Next ()
		{
			soldiers[current].OnTurn ();
			current = (current + 1) % soldiers.Length;
		}
	}
}