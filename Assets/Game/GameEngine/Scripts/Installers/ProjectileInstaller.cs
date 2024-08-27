using UnityEngine;

public sealed class ProjectileInstaller : EntityInstaller
{
	[SerializeField]
	private float _moveSpeed;
	[SerializeField]
	private int _damage;
	[SerializeField]
	private float _deathTimer;
	[SerializeField]
	private ProjectileCollisionDispatcher _dispatcher;

	public override void Install(GameEntity entity)
	{
		entity.AddPosition(transform.position);
		entity.AddRotation(transform.rotation);
		entity.AddMoveSpeed(_moveSpeed);
		entity.AddMoveDirection(transform.forward);

		entity.AddDamage(_damage);
		entity.AddDeathTimer(_deathTimer);
		entity.AddTypeId("Projectile");
		entity.AddTransformView(transform);
		_dispatcher.Construct();
	}

	public override void Dispose(GameEntity entity)
	{
	}
}