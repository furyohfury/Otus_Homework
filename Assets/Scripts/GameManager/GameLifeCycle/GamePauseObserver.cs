using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class GamePauseObserver : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private GameManager _gameManager;
        private bool _paused = false;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(() => PauseButtonPressed());
        }

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