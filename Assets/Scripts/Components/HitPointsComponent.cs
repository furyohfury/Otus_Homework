using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class HitPointsComponent
    {
        public event Action OnHPEnded;

        [SerializeField] private int _hitPoints;

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                OnHPEnded?.Invoke();
            }
        }
    }
}