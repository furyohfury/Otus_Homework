using Unity.Cinemachine;
using UnityEngine;

namespace Game
{
	public sealed class CameraShaker
	{
		private readonly CinemachineImpulseSource _impulseSource;

		public CameraShaker(CinemachineImpulseSource impulseSource)
		{
			_impulseSource = impulseSource;
		}

		public void ShakeCamera(Vector2 direction, float duration = 0.15f, float force = 0.35f)
		{
			var velocity = new Vector3(direction.x * force, direction.y * force);
			_impulseSource.ImpulseDefinition.ImpulseDuration = duration;
			_impulseSource.GenerateImpulse(velocity);
		}
	}
}