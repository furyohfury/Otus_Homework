using System;
using UnityEngine;

namespace Game
{
	public sealed class AnimatedVFX : MonoBehaviour
	{
		public event Action OnEnded; 
		
		public void EndAndDestroy()
		{
			OnEnded?.Invoke();
			Destroy(gameObject);
		}

		public void EndAndHide()
		{
			OnEnded?.Invoke();
			gameObject.SetActive(false);
		}
		
		public void Show()
		{
			gameObject.SetActive(true);
		}
	}
}