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
			var instance = _diContainer.InstantiatePrefab(handle.Result, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint.parent);
			var releaser = instance.AddComponent<GameObjectAssetReleaser>();
			releaser.SetAsset(_assetReference);
			if (_spawnPoint == this.transform)
			{
				Destroy(this);
			}
			else
			{
				Destroy(_spawnPoint.gameObject);
				Destroy(this.gameObject);
			}			
		}

		private void OnDestroy()
		{
			_assetReference.ReleaseAsset();
		}
	}
}