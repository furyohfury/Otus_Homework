using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace SampleGame
{
	public sealed class GameObjectAssetLoader : MonoBehaviour
	{
		[SerializeField]
		private AssetReferenceGameObject _assetReference;
		private DiContainer _diContainer;

		[Inject]
		public void Construct(DiContainer container)
		{
			_diContainer = container;
		}
		
		private void Start()
		{
			_assetReference.LoadAssetAsync().Completed += OnCompleted;
		}

		private void OnCompleted(AsyncOperationHandle<GameObject> handle)
		{
			_diContainer.InstantiatePrefab(handle.Result, transform.parent);
			Destroy(gameObject);
		}
	}
}