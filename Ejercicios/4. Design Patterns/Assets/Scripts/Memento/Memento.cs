using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
	public class Memento : MonoBehaviour
	{	
		public Transform character;
		private Stack<CharacterState> states;

		private void Awake ()
		{
			states = new Stack<CharacterState> ();
		}

		private void Start ()
		{
			Record ();
		}
		
		private void Update () 
		{
			if (Input.GetKeyDown (KeyCode.R))
				Record ();
			if (Input.GetKeyDown (KeyCode.B))
				RestoreLast ();	
		}

		private void Record ()
		{
			CharacterState current = CharacterState.Build (character);
			states.Push (current);
		}

		private void RestoreLast ()
		{
			CharacterState last = states.Pop ();
			last.Restore (character);
			if (states.Count == 0)
				Record ();
		}
	}
}