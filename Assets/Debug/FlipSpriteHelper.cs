using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public class FlipSpriteHelper : MonoBehaviour
	{
		[SerializeField]
		private GameObject _target;

		[Button]
		private void  FlipAllX(bool flip)
		{
			var renderers = GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0, count = renderers.Length; i < count; i++)
			{
				renderers[i].flipX = flip;
			}
		}
	}
}