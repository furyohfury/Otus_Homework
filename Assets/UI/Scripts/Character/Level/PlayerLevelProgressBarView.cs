using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelProgressBarView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _experience;
        [SerializeField]
        private RectTransform _uncompletedBar;
        [SerializeField]
        private RectTransform _completedBar;
        [SerializeField]
        private TweenParams _tweenParams;

        private IPlayerLevelProgressBarPresenter _presenter;
        private CompositeDisposable _disposable = new();
        private float _barsWidth = 0f;

        public void Show(IPresenter presenter)
        {
            if (presenter is not IPlayerLevelProgressBarPresenter playerLevelProgressBarPresenter)
            {
                throw new System.Exception("Needed playerLevelProgressBarPresenter");
            }

            if (_barsWidth == 0f)
            {
                if (_uncompletedBar.sizeDelta.x - _completedBar.sizeDelta.x > 1)
                {
                    throw new System.Exception("Progress bars must have same width");
                }
                _barsWidth = _completedBar.sizeDelta.x;
            }

            _presenter = playerLevelProgressBarPresenter;
            playerLevelProgressBarPresenter.Experience
                .Subscribe(SetExperience);
            playerLevelProgressBarPresenter.ProgressBarFillRate
                .Subscribe(SetProgressBar);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _presenter.Dispose();
            _disposable.Clear();
            gameObject.SetActive(false);
        }

        private void SetExperience(string exp) => _experience.text = exp;

        [Button]
        private void SetProgressBar(float fillRate)
        {
            DOTween.To(() => _completedBar.sizeDelta.x,
             x => _completedBar.sizeDelta = new Vector2(x, _completedBar.sizeDelta.y),
             fillRate * _barsWidth,
             _tweenParams.Duration);
        }
    }
}