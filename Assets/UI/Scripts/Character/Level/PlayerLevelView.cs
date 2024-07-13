using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _level;
        [SerializeField]
        private TMP_Text _experience;
        [SerializeField]
        private RectTransform _uncompletedBar;
        [SerializeField]
        private RectTransform _completedBar;

        private IPlayerLevelPresenter _presenter;
        private float _barsWidth;
        private readonly float _duration = 1; // todo put somewhere else
        private CompositeDisposable _disposable = new();

        private void Awake()
        {
            if (_uncompletedBar.rect.width - _completedBar.rect.width > 1)
            {
                throw new System.Exception("Progress bars must have same width");
            }
            _barsWidth = _completedBar.sizeDelta.x;
        }

        public void Show(IPresenter presenter)
        {
            if (presenter is not IPlayerLevelPresenter playerLevelPresenter)
            {
                throw new System.Exception("Needed playerLevelPresenter");
            }

            _presenter = playerLevelPresenter;
            gameObject.SetActive(true);
            playerLevelPresenter.Level.
                Subscribe(SetLevel);
            playerLevelPresenter.Experience
                .Subscribe(SetExperience);
            playerLevelPresenter.ProgressBarFillRate
                .Subscribe(SetProgressBar);
            
        }

        public void Hide()
        {
            _presenter.Dispose();
            _disposable.Clear();
            gameObject.SetActive(false);
        }

        private void SetLevel(string level) => _level.text = level;
        private void SetExperience(string exp) => _experience.text = exp;

        [Button]
        private void SetProgressBar(float fillRate)
        {
            DOTween.To(() => _completedBar.sizeDelta.x,
             x => _completedBar.sizeDelta = new Vector2(x, _completedBar.sizeDelta.y),
             fillRate * _barsWidth,
             _duration);
        }
    }
}