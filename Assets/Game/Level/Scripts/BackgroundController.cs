using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class BackgroundController : IInitializable, IGameLateTickable
	{
		private readonly Transform _backGroundTransform;
		private readonly Camera _camera;
		private Vector3 _offset;

		[Inject]
		public BackgroundController(Transform backGroundTransform, Camera camera)
		{
			_backGroundTransform = backGroundTransform;
			_camera = camera;
		}


		public void Initialize()
		{
			_offset = _backGroundTransform.position - _camera.transform.position;
		}

		public void LateTick(float deltaTime)
		{
			_backGroundTransform.position = _camera.transform.position + _offset;
		}
	}
}