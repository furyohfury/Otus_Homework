using TMPro;
using UniRx;
using UnityEngine;

namespace Popup.UI.Character.Stats
{
    public class CharacterStatView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _stat;

        private IStatPresenter _presenter;
        private readonly CompositeDisposable _disposable = new();

        public void SetStat(string stat) => _stat.text = stat;

        public void Show(IPresenter presenter)
        {
            if (presenter is not IStatPresenter statPresenter)
            {
                throw new System.Exception("Needed IStatPresenter");
            }
            _presenter = statPresenter;
            statPresenter.Stat
                .Subscribe(SetStat)
                .AddTo(_disposable);

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _disposable.Clear();
            _presenter.Dispose();
            gameObject.SetActive(false);
        }
    }
}