using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace SampleGame
{
	public sealed class GameObjectAssetLoader : MonoBehaviour
	{
		[SerializeField]
		private bool _spawnOnStart = true;
		[SerializeField]
		private AssetReferenceGameObject _assetReference;
		[SerializeField]
		private Transform _spawnPoint;
		private DiContainer _diContainer;

		[Inject]
		public void Construct(DiContainer container)
		{
			_diContainer = container;
		}
		
		private void Start()
		{
			if (_spawnOnStart)
			{
				Spawn();
			}			
		}

		public void Spawn()
		{
			_assetReference.LoadAssetAsync().Completed += OnCompleted;
		}

		private void OnCompleted(AsyncOperationHandle<GameObject> handle)
		{
			_diContainer.InstantiatePrefab(handle.Result, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint.parent);
			Destroy(_spawnPoint.gameObject);
		}

		private void OnDestroy()
		{
			_assetReference.ReleaseAsset();
		}
	}
}