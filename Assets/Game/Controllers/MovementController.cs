using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;
using ITickable = Zenject.ITickable;

namespace Game
{
	public sealed class MovementController : IInitializable, ITickable
	{
		private readonly IEntity _character;
		private Rigidbody2D _rigidbody;
		private ReactiveVariable<Vector2> _moveDirection;
		private readonly Camera _camera;

		[Inject]
		public MovementController(IEntity character, Camera camera)
		{
			_character = character;
			_camera = camera;
		}

		public void Initialize()
		{
			if (_character.TryGetMoveDirection(out _moveDirection) == false)
			{
				Debug.LogError("Cant find character movedirection");
			}

			_rigidbody = _character.GetRigidbody();
			SetMouseAsTarget();
		}

		public void Tick()
		{
			Movement();
			Jumping();
			Shooting();
			Ability();
		}

		private void SetMouseAsTarget()
		{
			var mousePosition = Input.mousePosition;
			mousePosition.z = _camera.transform.position.z;
			if (_character.HasTarget())
			{
				return;
			}

			_character.AddTarget(new BaseFunction<Vector2>(
				() => _camera.ScreenToWorldPoint(new Vector3(
					Input.mousePosition.x,
					Input.mousePosition.y, Mathf.Abs(_camera.transform.position.z)))));
		}

		private void Movement()
		{
			var input = Input.GetAxis("Horizontal");
			var direction = new Vector2(input, 0);
			_moveDirection.Value = direction;
		}

		private void Jumping()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (_character.TryGetJumpRequest(out var request))
				{
					request.Invoke();
				}
			}
		}

		private void Shooting()
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				if (_character.TryGetAttackRequest(out var request))
				{
					request.Invoke();
				}
				else
				{
					Debug.Log("No attackrequest on character");
				}
			}
		}

		private void Ability()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (_character.TryGetAbilityEvent(out var abilityEvent))
				{
					abilityEvent.Invoke();
				}
			}
		}
	}
}