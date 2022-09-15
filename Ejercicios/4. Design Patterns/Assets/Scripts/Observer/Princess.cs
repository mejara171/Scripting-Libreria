using System;
using UnityEngine;

public class Princess : MonoBehaviour 
{

	public event Action OnDead;

	private void OnMouseDown ()
	{
		Die ();
	}

	private void Die ()
	{
		if (OnDead != null)
			OnDead ();
		Destroy (gameObject);
	}
}
