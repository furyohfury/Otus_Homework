using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class CharacterVfx
    {
        [SerializeField]
        private ParticleSystem _muzzleVfx;
        [SerializeField]
        private ParticleSystem _takeDamageVfx;

        public void Compose(IAtomicEvent shootEvent, IAtomicEvent<int> takeDamageEvent)
        {
            shootEvent.Subscribe(OnShoot);
            takeDamageEvent.Subscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            _takeDamageVfx.Play();
        }

        private void OnShoot()
        {
            _muzzleVfx.Play();
        }
    }
}
