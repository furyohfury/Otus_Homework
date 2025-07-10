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

		public PlayerTargetController(Camera camera, PlayerService playerService, InputReader inputReader)
		{
			_camera = camera;
			_playerService = playerService;
			_inputReader = inputReader;
		}

		public void Initialize()
		{
			var playerEntity = _playerService.Player;
#if UNITY_STANDALONE_WIN || UNITY_WEBGL
			AddMouseCursorAsTarget(playerEntity);
#endif
#if UNITY_ANDROID
			AddRightStickAsTarget(playerEntity);
#endif
		}

		private void AddMouseCursorAsTarget(IEntity playerEntity)
		{
			var target = new BaseFunction<Vector2>(GetMouseWorldPosition);
			SetTargetToEntity(playerEntity, target);
		}

		private void AddRightStickAsTarget(IEntity player)
		{
			Vector2 lastValidTarget = Vector2.zero;

			var target = new BaseFunction<Vector2>(
				() =>
				{
					var stickDirection = _inputReader.RightStickDirection;

					if (stickDirection != Vector2.zero)
					{
						lastValidTarget = (Vector2)player.GetVisualTransform().position + stickDirection * 100f;
					}

					return lastValidTarget;
				});
			SetTargetToEntity(player, target);
		}

		private static void SetTargetToEntity(IEntity entity, BaseFunction<Vector2> target)
		{
			if (entity.AddTarget(target) == false)
			{
				entity.SetTarget(target);
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