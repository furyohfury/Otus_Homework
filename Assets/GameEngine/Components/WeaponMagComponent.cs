using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class WeaponMagComponent
    {
        public IAtomicEvent SpendBullet;
        public AtomicEvent AddBullet;
        public AtomicVariable<int> CurrentCount = new(10);
        public AtomicFunction<bool> IsEmpty = new();
        public AtomicFunction<bool> IsFull = new();
        public AtomicVariable<int> MaxCount = new(10);

        public void Compose(IAtomicEvent spendBulletAction)
        {
            IsEmpty.Compose(() => CurrentCount.Value <= 0);
            IsFull.Compose(() => CurrentCount.Value == MaxCount.Value);
            spendBulletAction.Subscribe(OnSpendBullet);
            AddBullet.Subscribe(OnAddBullet);
        }

        private void OnAddBullet()
        {
            if (CurrentCount.Value != MaxCount.Value)
            {
                CurrentCount.Value++;
            }
        }

        private void OnSpendBullet()
        {
            var leftBullets = CurrentCount.Value - 1;
            CurrentCount.Value = leftBullets > 0 ? leftBullets : 0;
        }
    }
}
