using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class StopSoundBlackboardAction : IBlackboardAction
	{
		[SerializeField]
		private AudioSource _audioSource;
		
		public void Invoke(IBlackboard blackboard)
		{
			_audioSource.Stop();
		}
	}
}