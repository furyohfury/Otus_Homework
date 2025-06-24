using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public sealed class SpriteMaterialChangeDebugHelper : MonoBehaviour
	{
#if UNITY_EDITOR
		[SerializeField]
		private SpriteRenderer[] _spriteRenderers;
		[SerializeField]
		private Material _defaultMaterial;
		[SerializeField]
		private Material _litMaterial;

		[Button]
		private void CollectSpriteRenderers()
		{
			_spriteRenderers = FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None)
			                   .Where(spriteRenderer => spriteRenderer.sharedMaterial == _defaultMaterial)
			                   .ToArray();
		}

		[Button]
		private void ChangeMaterialToSpriteRenderers()
		{
			for (int i = 0, count = _spriteRenderers.Length; i < count; i++)
			{
				_spriteRenderers[i].sharedMaterial = _litMaterial;
			}
		}
#endif
	}
}