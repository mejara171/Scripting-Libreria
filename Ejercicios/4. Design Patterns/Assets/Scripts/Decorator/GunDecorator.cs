namespace Patterns
{
    public abstract class GunDecorator : IWeapon
    {
		private IWeapon decorated;

		public GunDecorator (IWeapon decorated)
		{
			this.decorated = decorated;
		}

        public void Shoot(Bullet bullet)
        {
			Decorate (bullet);
			decorated.Shoot (bullet);
        }

		public abstract void Decorate (Bullet bullet);
    }
}