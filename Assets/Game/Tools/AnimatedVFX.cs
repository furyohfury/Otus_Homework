using System;
using UnityEngine;

namespace Game
{
	public sealed class AnimatedVFX : MonoBehaviour
	{
		public event Action OnEnded; 
		
		public void AnimationEnded()
		{
			OnEnded?.Invoke();
			Destroy(gameObject);
		}
	}
}