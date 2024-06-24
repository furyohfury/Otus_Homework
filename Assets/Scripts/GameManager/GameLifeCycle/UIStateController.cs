using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class UIStateController : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            IGameStateListener.Register(this);
            _pauseButton.gameObject.SetActive(false);
        }

        void IGameStartListener.StartGame()
        {
            _startButton.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);
        }

        void IGameFinishListener.FinishGame()
        {
            _pauseButton.gameObject.SetActive(false);
        }
    }
}