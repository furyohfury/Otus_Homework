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
            this.hitPoints -= damage;
            if (this.hitPoints <= 0)
            {
                this.OnHPEnded?.Invoke();
            }
        }

        public bool IsHitPointsExists() => hitPoints > 0;
    }
}