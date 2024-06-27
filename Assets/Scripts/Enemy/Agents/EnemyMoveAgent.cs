using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        public event Action OnReachedDestination;

        [SerializeField] private MoveComponent _moveComponent;
        private Vector2 _destination;
        private Coroutine _coroutine;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(GetToDestination());
        }

        private IEnumerator GetToDestination()
        {
            while (true)
            {
                Vector2 distance = _destination - (Vector2)transform.position;
                if (distance.magnitude <= 0.05f)
                {
                    OnReachedDestination?.Invoke();
                    _coroutine = null;
                    yield break;
                }
                else
                {
                    distance.Normalize();
                    _moveComponent.MoveByRigidbodyVelocity(distance * Time.fixedDeltaTime);
                    yield return new WaitForFixedUpdate();
                }
            }
        }

        public void PauseGame()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        public void ResumeGame()
        {
            Vector2 distance = _destination - (Vector2)transform.position;
            if (_coroutine != null && distance.magnitude > 0.05f)
            {
                _coroutine = StartCoroutine(GetToDestination());
            }
        }

        public void FinishGame()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }
}