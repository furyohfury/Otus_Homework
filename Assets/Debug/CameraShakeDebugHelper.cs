using Game;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameDebug
{
	public sealed class CameraShakeDebugHelper : MonoBehaviour
	{
#if UNITY_EDITOR
		private CameraShaker _cameraShaker;

		[Inject]
		private void Construct(CameraShaker cameraShaker)
		{
			_cameraShaker = cameraShaker;
		}

		// [Button]
		// private void Shake(float duration, float strength)
		// {
		// 	_cameraShaker.ShakeCamera(Vector2.up, duration, strength);
		// }
		
		[Button]
		private void ShakeDefault()
		{
			_cameraShaker.ShakeCamera(Vector2.up);
		}
#endif
	}
}