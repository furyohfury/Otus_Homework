using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    public sealed class UIStateController : IInitializable, IGameStartListener, IGameFinishListener
    {
        private readonly Button _pauseButton;
        private readonly Button _startButton;

        public UIStateController(Button pauseButton, Button startButton)
        {
            _pauseButton = pauseButton;
            _startButton = startButton;
        }

        void IInitializable.Initialize()
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