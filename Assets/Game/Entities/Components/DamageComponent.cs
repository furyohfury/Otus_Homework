namespace Entities
{
	public sealed class DamageComponent : IComponent // TODO mb unite with hp to stats component
	{
		public int Damage;

		public DamageComponent(int damage)
		{
			Damage = damage;
		}
	}
}