using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class CharacterAudio
    {
        [SerializeField] 
        private AudioSource _audioSource;
        [SerializeField] 
        private AudioClip _shootSfx;
        [SerializeField]
        private AudioClip _takeDamageSfx;
        [SerializeField]
        private AudioClip _deathSfx;

        public void Compose(IAtomicEvent shootEvent, IAtomicEvent takeDamageEvent, IAtomicObservable<bool> alive)
        {
            shootEvent.Subscribe(OnShoot);
            takeDamageEvent.Subscribe(OnTakeDamage);
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

        private void OnTakeDamage()
        {
            _audioSource.clip = _takeDamageSfx;
            _audioSource.Play();
        }

        private void OnShoot()
        {
            _audioSource.clip = _shootSfx;
            _audioSource.Play();
        }
    }
}
