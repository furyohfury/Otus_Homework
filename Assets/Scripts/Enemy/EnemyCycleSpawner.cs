using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCycleSpawner : MonoBehaviour, , IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        [SerializeField] private int _countdown = 1;
        [SerializeField] private int _maxEnemies = 7;
        [SerializeField] private EnemySystem _enemySystem;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }
        
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_countdown);
                if (_enemySystem.GetCountOfActive() < _maxEnemies)
                {
                    _enemySystem.GetEnemy();
                }
            }
        }

        public void PauseGame() // todo check if coroutine pauses or nothing changes
        {
            enabled = false;
        }

        public void ResumeGame()
        {
            enabled = true;
        }

        public void FinishGame()
        {
            enabled = false;
        }
    }
}