using UnityEngine;
using Zenject;

namespace Patterns
{
	[RequireComponent (typeof (Rigidbody))]
	public class InjectedBullet : MonoBehaviour
	{
		[Inject]
		private InjectedBulletPool pool;

		public float damage = 20f;
		private new Rigidbody rigidbody;

		private void Awake () 
		{
			rigidbody = GetComponent <Rigidbody> ();		
		}

		private void OnCollisionEnter (Collision collision)
		{
			pool.ReleaseBullet (this);
		}
	}
}