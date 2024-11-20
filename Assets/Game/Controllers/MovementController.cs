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
		private ReactiveVariable<Vector2> _moveDirection;

		[Inject]
		public MovementController(IEntity character)
		{
			_character = character;
		}

		public void Initialize()
		{
			if (_character.TryGetMoveDirection(out _moveDirection) == false)
			{
				Debug.LogError("Cant find character movedirection");
			}
		}

		public void Tick()
		{
			var input = Input.GetAxis("Horizontal");
			var direction = new Vector2(input, 0);

			_moveDirection.Value = direction;

			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (_character.TryGetJumpAction(out var action))
				{
					action.Invoke();
				}
			}
		}
	}
}