using UnityEngine;

namespace Game
{
	public sealed class DestroyAnimationComponent : MonoBehaviour
	{
		public void DestroyObject()
		{
			Destroy(gameObject);
		}
	}
}