using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class FootstepsSFXBehaviour : IEntityInit, IEntityUpdate
	{
		private AudioSource _audioSource;
		private AudioClip[] _footstepsSounds;
		private ReactiveVariable<Vector2> _moveDirection;
		private BaseFunction<bool> _isGrounded;

		public void Init(IEntity entity)
		{
			_audioSource = entity.GetAudioSource();
			_footstepsSounds = entity.GetFootstepsSounds();
			_moveDirection = entity.GetMoveDirection();
			_isGrounded = entity.GetIsGrounded();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (_moveDirection.Value == Vector2.zero
			    || _isGrounded.Value == false
			    || _audioSource.isPlaying)
			{
				return;
			}

			var clip = _footstepsSounds[Random.Range(0, _footstepsSounds.Length)];
			_audioSource.PlayOneShot(clip);
		}
	}
}