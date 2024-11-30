using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public class DashXAbilityBehaviour : IEntityInit, IEntityDispose
	{
		private IValue<float> _dashForce;
		private Rigidbody2D _rigidbody;
		private IFunction<Vector2> _target;
		private BaseEvent _abilityEvent;

		public void Init(IEntity entity)
		{
			_dashForce = entity.GetDashForce();
			_rigidbody = entity.GetRigidbody();
			_target = entity.GetTarget();

			_abilityEvent = entity.GetAbilityEvent();
			_abilityEvent.Subscribe(OnDashAbility);
		}

		private void OnDashAbility()
		{
			_rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
			var direction = _target.Invoke() - _rigidbody.position;
			var sign = Mathf.Sign(direction.x);

			_rigidbody.AddForce(new Vector2(_dashForce.Value * sign, 0));
			// _rigidbody.velocity += new Vector2(_dashForce.Value * sign, 0);
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnDashAbility);
		}
	}
}