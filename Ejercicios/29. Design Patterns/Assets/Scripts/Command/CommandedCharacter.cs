using System.Collections;
using UnityEngine;

namespace Patterns
{
	public class CommandedCharacter : MonoBehaviour
	 {

		private new Renderer renderer;

		private void Awake ()
		{
			renderer = GetComponent<Renderer> ();
		}

		public void Move(int x, int y)
		{
			Debug.Log ("Move");
			transform.position+= new Vector3 (x, 0f, y);
		}

		public void Attack ()
		{
			Debug.Log ("Attack");
			renderer.material.color = Color.red;
			StartCoroutine (TurnWhite ());
		}

		private IEnumerator TurnWhite ()
		{
			yield return new WaitForSeconds (1f);
			renderer.material.color = Color.white;
		}
	}
}
