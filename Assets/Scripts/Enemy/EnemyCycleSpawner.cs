using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCycleSpawner : MonoBehaviour, IGamePauseListener, IGameResumeListener, IGameFinishListener, IGameStartListener
    {
        [SerializeField] private int _countdown = 1;
        [SerializeField] private int _maxEnemies = 7;
        [SerializeField] private EnemySystem _enemySystem;

        private bool _active = false;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        private IEnumerator Start() // doesnt work
        {
            while (true)
            {
                yield return new WaitForSeconds(_countdown);
                if (_active && _enemySystem.GetCountOfActive() < _maxEnemies)
                {
                    _enemySystem.GetEnemy();
                }
            }
        }

        public void StartGame()
        {
            _active = true;
        }

        public void PauseGame()
        {
            _active = false;
        }

        public void ResumeGame()
        {
            _active = true;
        }

        public void FinishGame()
        {
            _active = false;
        }
    }
}