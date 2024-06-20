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