using UnityEngine;
using UnityEngine.Serialization;

public sealed class ProjectileInstaller : EntityInstaller
{
	[SerializeField]
	private float _moveSpeed;
	[SerializeField]
	private int _damage;
	[SerializeField]
	private float _deathTimer;
	[SerializeField]
	private ArrowCollisionDispatcher _dispatcher;

	public override void Install(GameEntity entity)
	{
		entity.AddPosition(transform.position);
		entity.AddRotation(transform.rotation);
		entity.AddMoveSpeed(_moveSpeed);
		entity.AddMoveDirection(transform.forward);
		entity.AddTransformView(transform);
		entity.AddDamage(_damage);
		entity.AddDeathTimer(_deathTimer);
		entity.AddTypeId("Projectile");
		_dispatcher.Construct();
	}

	public override void Dispose(GameEntity entity)
	{
	}
}