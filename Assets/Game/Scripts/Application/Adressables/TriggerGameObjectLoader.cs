using UnityEngine;
using Zenject;

namespace SampleGame
{
	[RequireComponent(typeof(Collider), typeof(GameObjectAssetLoader))]
	public sealed class TriggerGameObjectAssetLoader : MonoBehaviour
	{
		[SerializeField]
		private GameObjectAssetLoader _loader;
		[SerializeField]
		private LayerMask _layerMask;
		[SerializeField]
		private Collider _collider;
		private DiContainer _diContainer;

		private void Awake()
		{
			_collider.isTrigger = true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (((1 << other.gameObject.layer) & _layerMask.value) == 0)
			{
				return;
			}
			_collider.enabled = false;
			_loader.Spawn();
		}
	}
}