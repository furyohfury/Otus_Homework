using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class PauseButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;        
        [SerializeField]
        private AssetReferenceGameObject _pauseScreenReference;
        private PauseScren _pauseScreen

        private void OnEnable()
        {
            _pauseScreen = _pauseScreenReference.LoadAssetAsync();
            _button.onClick.AddListener(this.pauseScreen.Show);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(this.pauseScreen.Show);
        }

        private void OnDestroy()
        {
            _pauseScreenReference.Release();
        }
    }
}