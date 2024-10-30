using System;
using Atomic.AI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Engine
{
	[Serializable]
	public sealed class PlaySoundBlackboardAction : IBlackboardAction
	{
		[SerializeField]
		private AudioSource _audioSource;
		[SerializeField]
		private AudioClip[] _audioClips;

		public void Invoke(IBlackboard blackboard)
		{
			_audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
		}
	}
}