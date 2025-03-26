using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace SampleGame
{
	public sealed class GameObjectAssetReleaser : MonoBehaviour
	{
		private AssetReferenceGameObject _assetReference;

		public void SetAsset(AssetReferenceGameObject reference)
		{
			_assetReference = reference;
		}

		private void OnDestroy()
		{
			ReleaseAsset();
		}

		public void ReleaseAsset()
		{
			_assetReference?.ReleaseAsset();
		}
	}
}