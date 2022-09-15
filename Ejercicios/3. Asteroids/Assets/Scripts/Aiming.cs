using UnityEngine;
using System.Collections;

namespace Asteroids
{
    public class Aiming : MonoBehaviour
    {
        public Rigidbody2D bullet;
        public float BulletSpeed = 8f;

        private void Update()
        {
            Vector3 direction = GetMouseAiming();
			transform.rotation = Quaternion.LookRotation (direction);

            if (Input.GetKeyDown(KeyCode.Space))
            {

                var BuletInst = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0,0)));
                BuletInst.velocity = new Vector3(direction.x, direction.y,direction.z)*BulletSpeed;
                

            }
        }

		private void OnDrawGizmos ()
		{
			Debug.DrawRay (transform.position, transform.forward);
		}

        public Vector3 GetMouseAiming()
        {
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouse.z = transform.position.z;
            Vector3 mouseDirection = (mouse - transform.position).normalized;
			return mouseDirection;
        }

    }
}