using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Game
{
	public static class AdressablesLoadManager // ne vishlo(
	{
		public static IReadOnlyDictionary<string, int> AssetReferenceCount => _assetReferenceCount;
		public static IReadOnlyDictionary<string, Object> LoadedAssets => _assets;

		private static readonly Dictionary<string, int> _assetReferenceCount = new();
		private static readonly Dictionary<string, Object> _assets = new();

		public static async Task<T> LoadAsset<T>(AssetReference assetReference) where T : Object
		{
			string guid = assetReference.AssetGUID;

			if (string.IsNullOrEmpty(guid))
			{
				throw new ArgumentException("GUID of asset was empty");
			}

			if (_assetReferenceCount.ContainsKey(guid))
			{
#if UNITY_EDITOR
				Debug.Log($"Asset with GUID {guid} was loaded from preload");
#endif
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
#if UNITY_EDITOR
			Debug.Log($"Asset with GUID {guid} was loaded");
#endif
			return asset;
		}

		public static async Task<T> LoadAsset<T>(string guid) where T : Object
		{
			return await LoadAsset<T>(new AssetReference(guid));
		}

		public static async void ReleaseAsset(AssetReference assetReference)
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

			_assetReferenceCount[guid]--;

			// If someone loaded asset in same frame, then dont release
			await Task.Yield();
			if (_assetReferenceCount.TryGetValue(guid, out count) == false)
			{
#if UNITY_EDITOR
				Debug.Log($"Asset with GUID {guid} was released by something already");
#endif
				return;
			}

			if (_assetReferenceCount[guid] < 1)
			{
#if UNITY_EDITOR
				Debug.Log($"Asset with GUID {guid} was released");
#endif
				Addressables.Release(_assets[guid]);
				_assetReferenceCount.Remove(guid);
				_assets.Remove(guid);
			}
		}

		public static void ReleaseAsset(string guid)
		{
			ReleaseAsset(new AssetReference(guid));
		}
	}
}