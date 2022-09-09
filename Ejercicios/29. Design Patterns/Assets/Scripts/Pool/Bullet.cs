using UnityEngine;

namespace Patterns
{
	[RequireComponent (typeof (Rigidbody))]
	public class Bullet : MonoBehaviour 
	{
		public float damage = 20f;
		private new Rigidbody rigidbody;

		private void Awake () 
		{
			rigidbody = GetComponent <Rigidbody> ();		
		}

		private void OnCollisionEnter (Collision collision)
		{
			BulletPool.Instance.ReleaseBullet (rigidbody);
		}
	}
}