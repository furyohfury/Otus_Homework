using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerTargetController : IInitializable
	{
		private readonly IEntity _character;
		private readonly Camera _camera;
		private readonly InputListener _inputListener;

		[Inject]
		public PlayerTargetController(IEntity character, Camera camera, InputListener inputListener)
		{
			_character = character;
			_camera = camera;
			_inputListener = inputListener;
		}

		public void Initialize()
		{
			AddTargetToCharacter();
		}

		private void AddTargetToCharacter()
		{
			if (_character.AddTarget(new BaseFunction<Vector2>(GetMouseWorldPosition)) == false)
			{
				_character.SetTarget(new BaseFunction<Vector2>(GetMouseWorldPosition));
			}
		}

		private Vector2 GetMouseWorldPosition()
		{
			var mousePosition = _inputListener.GetMousePosition();
			var cameraOffset = Mathf.Abs(_camera.transform.position.z);
			var mouseOffsetPosition = new Vector3(
				mousePosition.x,
				mousePosition.y,
				cameraOffset);

			return _camera.ScreenToWorldPoint(mouseOffsetPosition);
		}
	}
}