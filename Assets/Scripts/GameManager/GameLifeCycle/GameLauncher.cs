using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private float _countdown = 3;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _gameStartButton;
        [SerializeField] private TextMeshProUGUI _buttonText;

        private void Awake()
        {
            _gameStartButton.onClick.AddListener(() => StartCoroutine(LaunchGame()));
        }

        public virtual IEnumerator LaunchGame()
        {
            float time = _countdown;
            while(time > 0.05)
            {
                _buttonText.text = time.ToString("f2");
                time -= Time.deltaTime;
                yield return null;
            }
            _gameManager.ChangeState(new GameStartState());
            _gameManager.HandleState();
        }
    }
}