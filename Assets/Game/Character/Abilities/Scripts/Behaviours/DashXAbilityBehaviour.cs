using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public class DashXAbilityBehaviour : IEntityInit, IEntityDispose
	{
        private IValue<float> _dashForce;
        private Rigidbody2D _rigidbody;
        private IValue<Vector2> _target;
		private BaseEvent _abilityEvent;

		public void Init(IEntity entity)
		{
            _dashForce = entity.GetDashForce();
            _rigidBody = entity.GetRigidbody();

			_abilityEvent = entity.GetAbilityEvent();
			_abilityEvent.Subscribe(OnDashAbility);
		}

		private void OnDashAbility()
		{
			var direction = _target - _rigidbody.position;
            var sign = Mathf.Sign(direction.x);

            _rigidBody.AddForce(new Vector2(_dashForce.Value * sign, 0));
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnDashAbility);
		}
	}
}