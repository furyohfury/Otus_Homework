using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class HeroPopupView : MonoBehaviour
    {
        [SerializeField] 
        private Button _exitButton;
        [SerializeField] 
        private Button _levelupButton;
        [SerializeField] 
        private UserView _userView;
        [SerializeField] 
        private PlayerLevelView _playerLevelView;
        [SerializeField]
        private PlayerLevelProgressBarView _progressBarView;
        [SerializeField] 
        private CharacterAllStatsView _characterAllStatsView;

        private IHeroPopupPresenter _heroPopupPresenter;
        private readonly CompositeDisposable _disposable = new();

        public void Show(IPresenter presenter)
        {
            if (presenter is not IHeroPopupPresenter heroPopupPresenter)
            {
                throw new System.Exception("Needed IHeroPopupPresenter");
            }
            _heroPopupPresenter = heroPopupPresenter;
            _userView.Show(_heroPopupPresenter.UserPresenter);
            _playerLevelView.Show(_heroPopupPresenter.PlayerLevelPresenter);
            _progressBarView.Show(_heroPopupPresenter.PlayerLevelProgressBarPresenter);
            _characterAllStatsView.Show(_heroPopupPresenter.CharacterAllStatsPresenter);

            _heroPopupPresenter.LevelUpButtonPresenter.LevelUpCommand
                .BindTo(_levelupButton)
                .AddTo(_disposable);
                
            _exitButton.onClick.AddListener(Hide);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _userView.Hide();
            _playerLevelView.Hide();
            _characterAllStatsView.Hide();
            _disposable.Clear();
            _exitButton.onClick.RemoveListener(Hide);
            gameObject.SetActive(false);
        }              
    }
}