using UnityEngine;

namespace Patterns
{
	[RequireComponent (typeof (Rigidbody))]
	public class Splicer : MonoBehaviour 
	{
		public float spliceTime;
		private float elapsedTime;

		public Rigidbody Rigidbody
		{
			get; private set;
		}
		
		private void Awake ()
		{
			Rigidbody = GetComponent<Rigidbody> ();
		}
		
		private void Update () 
		{
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= spliceTime)
				TrySplice ();
		}

		private void TrySplice ()
		{
			if (transform.localScale.x < 0.1f)
				Destroy (gameObject);
			else
				Splice ();
		}

		private void Splice ()
		{
			transform.localScale *= 0.5f;
			elapsedTime = 0f;
			Splicer clone = Clone ();
		}

		public Splicer Clone ()
		{
			return Instantiate (this);
		}
	}
}