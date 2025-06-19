using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public sealed class AnimatorSpeedDebugHelper : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		[Button]
		public void PrintAnimatorSpeed()
		{
			Debug.Log(_animator.speed);
		}
	}
}