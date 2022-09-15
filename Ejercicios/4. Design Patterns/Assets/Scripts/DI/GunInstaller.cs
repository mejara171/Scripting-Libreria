using Zenject;

namespace Patterns
{
	public class GunInstaller : MonoInstaller 
	{
		public InjectedBullet bullet;

		public override void InstallBindings ()
		{
			Container.Bind<InjectedBullet> ().FromInstance (bullet);
			Container.Bind<InjectedBulletPool> ().AsSingle ();
		}
	}
}