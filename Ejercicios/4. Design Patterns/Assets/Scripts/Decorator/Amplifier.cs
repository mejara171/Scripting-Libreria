namespace Patterns
{
    public class Amplifier : GunDecorator
    {
		public Amplifier (IWeapon decorated): base(decorated)
		{
		}


        public override void Decorate(Bullet bullet)
        {
            bullet.damage += 30f;
        }
    }
}