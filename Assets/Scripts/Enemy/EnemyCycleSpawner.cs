using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCycleSpawner : MonoBehaviour
    {
        public event Action OnSpawnEnemy;

        [SerializeField] private int _countdown = 1;
        [SerializeField] private int _maxEnemies = 7;
        
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_countdown);
                if (_enemyFactory.GetCountOfActive() < _maxEnemies)
                {
                    OnSpawnEnemy?.Invoke();
                }
            }
        }
    }
}