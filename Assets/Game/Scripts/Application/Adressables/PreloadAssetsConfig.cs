using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
	[CreateAssetMenu(fileName = "PreloadAssetsConfig", menuName = "Create config/Addressables/PreloadAssetsConfig", order = 0)]
	public sealed class PreloadAssetsConfig : ScriptableObject
	{
		public AssetReference[] PreloadedAssets => _preloadAssets;
		
		[SerializeField]
		private AssetReference[] _preloadAssets;
	}
}