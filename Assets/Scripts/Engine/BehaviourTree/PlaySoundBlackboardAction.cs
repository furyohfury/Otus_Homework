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
		private AudioClip[] _audioClips;

		public void Invoke(IBlackboard blackboard)
		{
			var audioSource = (AudioSource)blackboard.GetAudioSource();
			// по идее надо отдельный инсталлер для audiosource но это уже детали фреймворка
			audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
		}
	}
}