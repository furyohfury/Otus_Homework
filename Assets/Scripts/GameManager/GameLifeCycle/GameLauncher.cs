using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class GameLauncher : MonoBehaviour
    {
        [SerializeField] private float _countdown = 3f;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _gameStartButton;
        [SerializeField] private TextMeshProUGUI _buttonText;

        private void Awake()
        {
            _gameStartButton.onClick.AddListener(() => LaunchGame());
        }

        private async void LaunchGame()
        {
            _gameStartButton.interactable = false;
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