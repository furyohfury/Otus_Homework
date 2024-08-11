using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class ZombieVfx
    {
        [SerializeField]
        private ParticleSystem _takeDamageVfx;

        public void Compose(IAtomicObservable<bool> isAlive)
        {
            isAlive.Subscribe(OnDead);
        }

        private void OnDead(bool alive)
        {
            if (!alive)
            {
                _takeDamageVfx.Play();
            }
        }
    }
}
