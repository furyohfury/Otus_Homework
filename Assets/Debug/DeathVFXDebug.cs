using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public class DeathVFXDebug : MonoBehaviour
	{
#if UNITY_EDITOR
		[SerializeField]
		private SpriteRenderer _spriteRenderer;
		[SerializeField]
		private float _dissolveDuration = 0.5f;
		[SerializeField]
		private GameObject _explodePrefab;

		[Button]
		private void SetFade(float f)
		{
			_spriteRenderer.material.SetFloat("Vector1_51DDBE76", f);
		}

		[Button]
		private void DissolveDeath()
		{
			_spriteRenderer.sharedMaterial.DOFloat(0, "Vector1_51DDBE76", _dissolveDuration);
		}

		[Button]
		private void ResetDissolve()
		{
			_spriteRenderer.sharedMaterial.SetFloat("Vector1_51DDBE76", 1);
		}

		[Button]
		private void ExplodeDeath()
		{
			_spriteRenderer.enabled = false;
			Instantiate(_explodePrefab, _spriteRenderer.transform.position, Quaternion.identity);
		}

		[Button]
		private void ResetExplode()
		{
			_spriteRenderer.enabled = true;
		}
#endif
	}
}