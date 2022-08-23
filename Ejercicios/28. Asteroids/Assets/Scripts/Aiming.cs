using UnityEngine;
using System.Collections;

namespace Asteroids
{
    public class Aiming : MonoBehaviour
    {
        private void Update()
        {
            Vector3 direction = GetMouseAiming();
			transform.rotation = Quaternion.LookRotation (direction);
        }

		private void OnDrawGizmos ()
		{
			Debug.DrawRay (transform.position, transform.forward);
		}

        private Vector3 GetMouseAiming()
        {
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouse.z = transform.position.z;
            Vector3 mouseDirection = (mouse - transform.position).normalized;
			return mouseDirection;
        }
    }
}