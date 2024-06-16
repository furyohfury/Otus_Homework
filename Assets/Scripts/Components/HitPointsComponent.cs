using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action OnHPEnded;
        
        [SerializeField] private int hitPoints;        

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                OnHPEnded?.Invoke();
            }
        }
    }
}