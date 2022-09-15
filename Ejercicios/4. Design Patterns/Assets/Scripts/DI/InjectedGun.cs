using UnityEngine;
using Zenject;

namespace Patterns
{
	public class InjectedGun : MonoBehaviour 
	{
		[Inject]
		private InjectedBulletPool pool;

		public float force;
		
		private void Update () 
		{
			if (Input.GetKeyDown (KeyCode.Space))
				Shoot ();	
		}

		private void Shoot ()
		{
			InjectedBullet bullet = pool.GetBullet ();
			bullet.transform.position = transform.position;
			Rigidbody rigidbody = bullet.GetComponent<Rigidbody> ();
			rigidbody.AddForce (transform.forward * force);
		}
	}
}