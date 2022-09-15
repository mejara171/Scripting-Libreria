using UnityEngine;
using System.Collections.Generic;

namespace Patterns
{
	public class BulletPool : MonoBehaviour {

		private static BulletPool instance;

		public static BulletPool Instance
		{
			get
			{
				return instance;	
			}
		}

		[SerializeField]
		private Rigidbody bulletPrefab;

		[SerializeField]
		private int size;

		private List<Rigidbody> bullets;

		private void Awake()
		{
			if (instance == null) {
				instance = this;
				PrepareBullets ();
			} else
				Destroy (gameObject);
		}

		private void PrepareBullets ()
		{
			bullets = new List<Rigidbody> ();
			for (int i = 0; i < size; i++)
				AddBullet ();
		}

		public Rigidbody GetBullet ()
		{
			if (bullets.Count == 0)
				AddBullet ();
			return AllocateBullet ();
		}

		public void ReleaseBullet (Rigidbody bullet)
		{
			bullet.gameObject.SetActive (false);
			bullets.Add (bullet);
		}

		private void AddBullet ()
		{
			Rigidbody instance = Instantiate (bulletPrefab);
			instance.gameObject.SetActive (false);
			bullets.Add (instance);
		}

		private Rigidbody AllocateBullet ()
		{
			Rigidbody bullet = bullets [bullets.Count - 1];
			bullets.RemoveAt (bullets.Count - 1);
			bullet.gameObject.SetActive (true);
			return bullet;
		}
	}
}