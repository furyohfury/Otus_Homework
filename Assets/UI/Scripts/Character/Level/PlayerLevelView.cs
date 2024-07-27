using TMPro;
using UniRx;
using UnityEngine;

namespace Popup.UI.Character.Level
{
    public sealed class PlayerLevelView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _level;

        private IPlayerLevelPresenter _presenter;
        private readonly CompositeDisposable _disposable = new();

        public void Show(IPresenter presenter)
        {
            if (presenter is not IPlayerLevelPresenter playerLevelPresenter)
            {
                throw new System.Exception("Needed playerLevelPresenter");
            }

            _presenter = playerLevelPresenter;
            gameObject.SetActive(true);
            playerLevelPresenter.Level.
                Subscribe(SetLevel)
                .AddTo(_disposable);
        }

        public void Hide()
        {
            _presenter.Dispose();
            _disposable.Clear();
            gameObject.SetActive(false);
        }

        private void SetLevel(string level) => _level.text = level;
    }
}