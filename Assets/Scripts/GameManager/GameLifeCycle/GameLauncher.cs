using DG.Tweening;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    public sealed class GameLauncher : IInitializable
    {
        private readonly float _countdown = 3f;
        private readonly GameManager _gameManager;
        private readonly Button _gameStartButton;
        private readonly TextMeshProUGUI _buttonText;

        public GameLauncher(float countdown, GameManager gameManager, Button gameStartButton)
        {
            _countdown = countdown;
            _gameManager = gameManager;
            _gameStartButton = gameStartButton;
            _buttonText = _gameStartButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }

        void IInitializable.Initialize() => _gameStartButton.onClick.AddListener(() => LaunchGame());

        private async void LaunchGame()
        {
            _buttonText.text = _countdown.ToString();
            DOTween.To(
                () => float.Parse(_buttonText.text),
                (x) => _buttonText.text = x.ToString("f2"),
                0,
                _countdown);
            await Task.Delay(System.TimeSpan.FromSeconds(_countdown));
            _gameManager.ChangeState(new GameStartState());
            _gameManager.HandleState();
        }
    }
}