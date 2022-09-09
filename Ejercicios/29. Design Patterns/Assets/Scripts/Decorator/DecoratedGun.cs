using UnityEngine;

namespace Patterns
{
    public class DecoratedGun : MonoBehaviour, IWeapon
    {
		public float force;

        public void Shoot(Bullet bullet)
        {
			Rigidbody rigidbody = bullet.GetComponent<Rigidbody> ();
			rigidbody.AddForce (transform.forward * force);
        }
    }
}