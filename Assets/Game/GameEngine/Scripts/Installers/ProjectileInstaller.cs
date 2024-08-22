using UnityEngine;

public sealed class ProjectileInstaller : EntityInstaller
{
	[SerializeField]
	private Transform _transform;
	[SerializeField]
	private float _moveSpeed;
	[SerializeField]
	private Team _team;
	[SerializeField]
	private int _damage;
	[SerializeField]
	private ArrowCollisionDispatcher _dispatcher;

	public override void Install(GameEntity entity)
	{
		// TODO add config
		entity.AddPosition(_transform.position);
		entity.AddDirection(_transform.rotation);
		entity.AddMoveSpeed(_moveSpeed);
		entity.AddMoveDirection(_transform.forward);
		entity.AddTeam(_team);
		entity.AddTransformView(_transform);
		entity.AddDamage(_damage);
		_dispatcher.Construct();
	}

	public override void Dispose(GameEntity entity)
	{
	}
}