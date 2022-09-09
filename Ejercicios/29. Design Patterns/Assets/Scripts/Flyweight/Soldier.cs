using UnityEngine;

namespace Patterns
{
	public class Soldier : MonoBehaviour {
		public int life;
		public int attack;
		public int defense;
		public LayerMask enemies;
		public float stepDistance;
		public Transform enemyBase;

		public SoldierMind mind;

		public Vector3 Direction
		{
			get
			{
				Vector3 direction = enemyBase.position - transform.position;
				direction.y = 0;
				return direction.normalized;
			}
		}
		
		public void OnTurn ()
		{
			mind.UpdateSoldier (this);
		}

		public void Attack (Soldier enemy)
		{
			Debug.Log ("Attack!");
			enemy.ApplyDamage (attack);
		}

		public void Move (Vector3 direction)
		{
			Debug.Log ("Move");
			transform.Translate (direction * stepDistance);
		}

		public void ApplyDamage (int damage)
		{
			damage = Mathf.Clamp (damage - defense, 0, damage);
			life -= damage;
			Debug.Log ("Ouch!");
		}
	}
}