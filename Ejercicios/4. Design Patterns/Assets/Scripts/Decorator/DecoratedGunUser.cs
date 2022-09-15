using UnityEngine;

namespace Patterns
{
	public class DecoratedGunUser: MonoBehaviour
	{
		public DecoratedGun baseGun;
		public Bullet bullet;
		private IWeapon gun;

		private void Awake ()
		{
			gun = baseGun;
		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.A))
				Amplify ();
			if (Input.GetKeyDown (KeyCode.Space))
				Shoot ();
		}	

		private void Amplify ()
		{
			Amplifier amplifier = new Amplifier (gun);
			gun = amplifier;
		}

		private void Shoot ()
		{
			Rigidbody instance = BulletPool.Instance.GetBullet ();
			instance.transform.position = transform.position;
			gun.Shoot (instance.GetComponent<Bullet> ());
		}
	}
}