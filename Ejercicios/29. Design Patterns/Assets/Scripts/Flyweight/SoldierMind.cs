using UnityEngine;

namespace Patterns
{
	public class SoldierMind : MonoBehaviour 
	{

		public void UpdateSoldier (Soldier soldier)
		{
			Soldier enemy;
			if (CheckForEnemies (soldier.transform.position, soldier.Direction, soldier.stepDistance, soldier.enemies, out enemy))
				HandleEnemy (soldier, enemy, soldier.Direction);
			else
				soldier.Move (soldier.Direction);
		}

		private bool CheckForEnemies (Vector3 position, Vector3 direction, float stepDistance, LayerMask enemies, out Soldier enemy)
		{
			RaycastHit hit;
			enemy = null;
			bool foundSomething = Physics.Raycast (position, direction, out hit, stepDistance, enemies);
			if (foundSomething)
				enemy = hit.collider.GetComponent<Soldier> ();
			return foundSomething;
		}

		private void HandleEnemy (Soldier me, Soldier enemy, Vector3 baseDirection)
		{
			if (me.life < enemy.attack)
				me.Move (baseDirection * -1f);
			else
				me.Attack (enemy);
		}
	}
}