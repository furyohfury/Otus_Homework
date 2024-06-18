using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCycleSpawner : MonoBehaviour
    {
        [SerializeField] private int _countdown = 1;
        [SerializeField] private int _maxEnemies = 7;
        [SerializeField] private EnemySystem _enemySystem;
        
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
    }
}