using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerTargetController : IInitializable
	{
		private readonly PlayerService _playerService;
		private readonly Camera _camera;
		private readonly InputReader _inputReader;

		[Inject]
		public PlayerTargetController(Camera camera, InputReader inputReader, PlayerService playerService)
		{
			_camera = camera;
			_inputReader = inputReader;
			_playerService = playerService;
		}

		public void Initialize()
		{
			var playerEntity = _playerService.Player;
			AddTargetToCharacter(playerEntity);
		}

		private void AddTargetToCharacter(IEntity playerEntity)
		{
			if (playerEntity.AddTarget(new BaseFunction<Vector2>(GetMouseWorldPosition)) == false)
			{
				playerEntity.SetTarget(new BaseFunction<Vector2>(GetMouseWorldPosition));
			}
		}

		private Vector2 GetMouseWorldPosition()
		{
			var mousePosition = InputReader.MousePosition;
			var cameraOffset = Mathf.Abs(_camera.transform.position.z);
			var mouseOffsetPosition = new Vector3(
				mousePosition.x,
				mousePosition.y,
				cameraOffset);

			return _camera.ScreenToWorldPoint(mouseOffsetPosition);
		}
	}
}