using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerTargetController : IInitializable, IGameTickable
	{
		private readonly PlayerService _playerService;
		private readonly Camera _camera;
		private CurrentDevice _currentDevice = CurrentDevice.Mouse;
		private Vector2 _mouseCachedPos;
		private Vector2 _gamepadRightStickCachedDirection;

		public PlayerTargetController(Camera camera, PlayerService playerService)
		{
			_camera = camera;
			_playerService = playerService;
		}

		public void Initialize()
		{
			var playerEntity = _playerService.Player;
			AddMouseCursorAsTarget(playerEntity);
		}

		public void Tick(float deltaTime)
		{
			var rightStickDirection = InputReader.RightStickDirection;
			if (_currentDevice == CurrentDevice.Gamepad && InputReader.MousePosition != _mouseCachedPos)
			{
				_currentDevice = CurrentDevice.Mouse;
				AddMouseCursorAsTarget(_playerService.Player);
			}
			else if (_currentDevice == CurrentDevice.Mouse && rightStickDirection != _gamepadRightStickCachedDirection)
			{
				_currentDevice = CurrentDevice.Gamepad;
				AddGamepadStickAsTarget(_playerService.Player);
			}

			_mouseCachedPos = InputReader.MousePosition;
			if (rightStickDirection != Vector2.zero)
			{
				_gamepadRightStickCachedDirection = rightStickDirection;
			}
		}

		private void AddMouseCursorAsTarget(IEntity playerEntity)
		{
			var target = new BaseFunction<Vector2>(GetMouseWorldPosition);
			if (playerEntity.AddTarget(target) == false)
			{
				playerEntity.SetTarget(target);
			}
		}

		private void AddGamepadStickAsTarget(IEntity playerEntity)
		{
			var target = new BaseFunction<Vector2>(GetRightStickPos);
			if (playerEntity.AddTarget(target) == false)
			{
				playerEntity.SetTarget(target);
			}
		}

		private Vector2 GetRightStickPos()
		{
			var rightStickDirection = InputReader.RightStickDirection * 5;
			Debug.Log(rightStickDirection);
			if (rightStickDirection != Vector2.zero)
			{
				return (Vector2)_playerService.Player.GetVisualTransform().position + rightStickDirection;
			}

			return (Vector2)_playerService.Player.GetVisualTransform().position + _gamepadRightStickCachedDirection;
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

		private enum CurrentDevice
		{
			Mouse
			, Gamepad
		}
	}
}