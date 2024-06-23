using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class UIStateController : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        void IGameStartListener.StartGame()
        {
            _startButton.gameObject.SetActive(false);
        }

        void IGameFinishListener.FinishGame()
        {
            _pauseButton.gameObject.SetActive(false);
        }
    }
}