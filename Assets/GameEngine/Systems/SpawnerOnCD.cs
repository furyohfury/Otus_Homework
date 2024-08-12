using System;
using System.Threading;
using Atomic.Elements;
using Atomic.Objects;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameEngine
{
    public sealed class SpawnerOnCD
    {
        public AtomicEvent<AtomicEntity> OnSpawnedEvent = new();
        private readonly float _cd;
        private readonly AtomicEntity _entity;
        private readonly Transform _container;
        private CancellationTokenSource _cancellationTokenSource = new();
        private readonly Transform[] _spawnPoints;

        public SpawnerOnCD(float cd, AtomicEntity entity, Transform container, Transform[] spawnPoints)
        {
            _cd = cd;
            _entity = entity;
            _container = container;
            _spawnPoints = spawnPoints;
        }

        public void Enable()
        {
            StartSpawning(_cancellationTokenSource.Token).Forget();
        }

        public void Disable()
        {
            _cancellationTokenSource.Cancel();
        }

        private async UniTask StartSpawning(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    _cancellationTokenSource = new();
                    break;
                }


                var spawnPos = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length - 1)];
                var enemy = Object.Instantiate(_entity, spawnPos.position, _entity.transform.rotation, _container);
                OnSpawnedEvent.Invoke(enemy);
                await UniTask.Delay(TimeSpan.FromSeconds(_cd));
            }
        }
    }
}