using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Game
{
	public static class AdressablesLoadManager
	{
		private static readonly Dictionary<string, int> _assetReferenceCount = new();
		private static readonly Dictionary<string, Object> _assets = new();

		public static async Task<T> LoadAsset<T>(AssetReference assetReference) where T : Object
		{
			string guid = assetReference.AssetGUID;

			if (_assetReferenceCount.ContainsKey(guid))
			{
				_assetReferenceCount[guid]++;
				return (T)_assets[guid];
			}

			T asset = await assetReference.LoadAssetAsync<T>().Task;
			if (asset == null)
			{
				throw new InvalidOperationException($"Asset with GUID {guid} could not be loaded.");
			}
			_assetReferenceCount.Add(guid, 1);
			_assets.Add(guid, asset);
			return asset;
		}

		public static async Task<T> LoadAsset<T>(string guid) where T : Object
		{
			return await LoadAsset<T>(new AssetReference(guid));
		}

		public static void ReleaseAsset(AssetReference assetReference)
		{
			string guid = assetReference.AssetGUID;

			if (!_assetReferenceCount.TryGetValue(guid, out int count))
			{
				Debug.LogWarning($"Asset with giud = {guid} was already released");
				return;
			}

			if (count > 1)
			{
				_assetReferenceCount[guid]--;
				return;
			}

			_assetReferenceCount.Remove(guid);
			_assets.Remove(guid);
			Addressables.Release(_assets[guid]);
		}

		public static void ReleaseAsset(string guid) => ReleaseAsset(new AssetReference(guid));
	}
}