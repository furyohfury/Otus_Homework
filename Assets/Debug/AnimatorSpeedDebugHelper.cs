using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public sealed class AnimatorSpeedDebugHelper : MonoBehaviour
	{
#if UNITY_EDITOR
		[SerializeField]
		private Animator _animator;

		[Button]
		public void PrintAnimatorSpeed()
		{
			Debug.Log(_animator.speed);
		}
#endif
	}
}