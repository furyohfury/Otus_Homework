using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public event Action OnReachedDestination;

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 _destination;
        private Coroutine _coroutine;

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
                var vector = _destination - (Vector2)transform.position;
                if (vector.magnitude <= 0.05f)
                {
                    OnReachedDestination?.Invoke();
                    yield break;
                }
                else
                {
                    vector.Normalize();
                    moveComponent.MoveByRigidbodyVelocity(vector * Time.fixedDeltaTime);
                    yield return new WaitForFixedUpdate();
                }
            }
        }
    }
}