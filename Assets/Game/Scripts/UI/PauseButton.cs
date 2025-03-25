using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
	public sealed class PauseButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;
		[SerializeField]
		private AssetReference _pauseScreenReference;
		private PauseScreen _pauseScreen;
		private DiContainer _diContainer;

		[Inject]
		private void Construct(DiContainer diContainer)
		{
			_diContainer = diContainer;
		}

		private void OnEnable()
		{
			_pauseScreenReference.LoadAssetAsync<GameObject>().Completed += handle =>
			{
				if (handle.Result != null)
				{
					var pauseScreenGo = _diContainer.InstantiatePrefab(handle.Result, transform.parent);
					pauseScreenGo.SetActive(false);
					_pauseScreen = pauseScreenGo.GetComponent<PauseScreen>();
					_button.onClick.AddListener(_pauseScreen.Show);
				}
			};
		}

		private void OnDisable()
		{
			if (_pauseScreen != null)
			{
				_button.onClick.RemoveListener(_pauseScreen.Show);
			}
		}

		private void OnDestroy()
		{
			_pauseScreenReference.ReleaseAsset();
		}
	}
}