using UnityEngine;

namespace Patterns
{
	public class Health : MonoBehaviour 
	{
		public float healthPoints;
		private float currentHealthPoints;
		private new Renderer renderer;

		private void Awake ()
		{
			renderer = GetComponent<Renderer> ();
		}

		private void Start ()
		{
			currentHealthPoints = healthPoints;
		}

		private void OnCollisionEnter (Collision collision)
		{
			Bullet bullet = collision.gameObject.GetComponent<Bullet> ();
			if (bullet)
				ApplyDamage (bullet.damage);
		}

		private void ApplyDamage (float damage)
		{
			currentHealthPoints -= damage;
			if (currentHealthPoints < 0)
				Destroy (gameObject);
			else
				renderer.material.color = Color.Lerp (Color.red, Color.white, currentHealthPoints / healthPoints);
		}
	}
}