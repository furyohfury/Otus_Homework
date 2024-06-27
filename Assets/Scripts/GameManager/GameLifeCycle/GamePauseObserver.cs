using TMPro;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    public class GamePauseObserver : IInitializable
    {
        private readonly Button _pauseButton;
        private readonly TextMeshProUGUI _text;
        private readonly GameManager _gameManager;
        private bool _paused = false;

        public GamePauseObserver(Button pauseButton, GameManager gameManager)
        {
            _pauseButton = pauseButton;
            _gameManager = gameManager;
            _text = pauseButton.GetComponentInChildren<TextMeshProUGUI>();
        }

        void IInitializable.Initialize() => _pauseButton.onClick.AddListener(() => PauseButtonPressed());

        private void PauseButtonPressed()
        {
            if (!_paused)
            {
                _paused = true;
                _text.text = "Resume";
                _gameManager.ChangeState(new GamePauseState());
            }
            else
            {
                _paused = false;
                _text.text = "Pause";
                _gameManager.ChangeState(new GameResumeState());
            }
            _gameManager.HandleState();
        }
    }
}