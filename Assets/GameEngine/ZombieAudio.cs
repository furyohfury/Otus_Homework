using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class ZombieAudio
    {
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private AudioClip _deathSfx;

        public void Compose(IAtomicObservable<bool> alive)
        {
            alive.Subscribe(OnDeath);
        }

        private void OnDeath(bool alive)
        {
            if (!alive)
            {
                _audioSource.clip = _deathSfx;
                _audioSource.Play();
            }
        }
    }
}
