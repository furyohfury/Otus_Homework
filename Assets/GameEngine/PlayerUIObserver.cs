using Atomic.Extensions;
using Atomic.Objects;
using TMPro;
using Zenject;

namespace GameEngine
{
    public sealed class PlayerUIObserver : IInitializable
    {
        private readonly TMP_Text _hpText;
        private readonly TMP_Text _bulletsText;
        private readonly TMP_Text _killsText;
        private int _killCount = 0;

        private readonly EnemySystem _enemySystem;
        private readonly AtomicObject _player;

        public PlayerUIObserver(TMP_Text hpText, TMP_Text bulletsText, TMP_Text killsText, EnemySystem enemySystem, AtomicObject player)
        {
            _hpText = hpText;
            _bulletsText = bulletsText;
            _killsText = killsText;
            _enemySystem = enemySystem;
            _player = player;
        }

        void IInitializable.Initialize()
        {
            if (_player.TryGetObservable<int>(LifeAPI.HIT_POINTS, out var hpObs))
            {
                hpObs.Subscribe(OnPlayerHPChanged);
                _hpText.text = _player.GetValue<int>(LifeAPI.HIT_POINTS).Value.ToString();
            }
            else
            {
                throw new System.Exception("Couldnt find player hp");
            }

            if (_player.TryGetObservable<int>(WeaponMagAPI.CURRENT_BULLET_COUNT, out var currentBulletsObs))
            {
                currentBulletsObs.Subscribe(OnCurrentBulletCountChanged);

                var curr = _player.GetValue<int>(WeaponMagAPI.CURRENT_BULLET_COUNT).Value;
                var max = _player.GetValue<int>(WeaponMagAPI.MAX_BULLET_COUNT).Value;
                _bulletsText.text = $"{curr}/{max}";
            }
            else
            {
                throw new System.Exception("Couldnt find player current bullets");
            }

            _enemySystem.OnEnemyKilledEvent.Subscribe(OnEnemyKilled);
            _killsText.text = _killCount.ToString();
        }

        private void OnEnemyKilled()
        {
            _killCount++;
            _killsText.text = _killCount.ToString();
        }

        private void OnCurrentBulletCountChanged(int count)
        {
            _bulletsText.text = $"{count}/{_player.GetValue<int>(WeaponMagAPI.MAX_BULLET_COUNT).Value}";
        }

        private void OnPlayerHPChanged(int hp)
        {
            _hpText.text = hp.ToString();
        }
    }
}
