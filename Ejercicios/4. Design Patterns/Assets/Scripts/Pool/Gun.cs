using UnityEngine;

namespace Patterns
{
	public class Gun : MonoBehaviour 
	{

		[SerializeField]
		private float force;

		private void Update ()
		{
			if (Input.GetMouseButtonDown (0))
				Shoot ();
		}

		private void Shoot ()
		{
			Rigidbody bullet = BulletPool.Instance.GetBullet ();
			bullet.transform.position = transform.position;
			bullet.AddForce (transform.forward * force);
		}
	}
}