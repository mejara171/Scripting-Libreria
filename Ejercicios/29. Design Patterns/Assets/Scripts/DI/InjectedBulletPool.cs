using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Patterns
{
	public class InjectedBulletPool 
	{
		private InjectedBullet prefab;
		private IInstantiator instantiator;
		private Queue<InjectedBullet> bullets;

		public InjectedBulletPool (InjectedBullet prefab, IInstantiator instantiator)
		{
			this.prefab = prefab;
			this.instantiator = instantiator;
			bullets = new Queue<InjectedBullet> ();
		}

		public void PrepareBullets (int amount)
		{
			for (int i=0; i<amount; i++)
				AddBullet ();
		}

		public InjectedBullet GetBullet ()
		{
			if (bullets.Count == 0)
				AddBullet ();
			return AllocateBullet ();
		}

		public void ReleaseBullet (InjectedBullet bullet)
		{
			bullet.gameObject.SetActive (false);
			bullets.Enqueue (bullet);
		}

		private void AddBullet ()
		{
			InjectedBullet instance = instantiator.InstantiatePrefabForComponent<InjectedBullet> (prefab);
			instance.gameObject.SetActive (false);
			bullets.Enqueue (instance);
		}

		private InjectedBullet AllocateBullet ()
		{
			InjectedBullet bullet = bullets.Dequeue ();
			bullet.gameObject.SetActive (true);
			return bullet;
		}
	}
}