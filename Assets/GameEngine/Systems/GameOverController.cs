using System;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class GameOverController : IInitializable
    {
        private readonly AtomicObject _player;
        private readonly GameManager _gameManager;
        private readonly GameObject _gameOverPopup;

        public GameOverController(AtomicObject player, GameManager gameManager, GameObject gameOverPopup)
        {
            _player = player;
            _gameManager = gameManager;
            _gameOverPopup = gameOverPopup;
        }

        void IInitializable.Initialize()
        {
            _player.GetObservable<bool>(LifeAPI.IS_ALIVE).Subscribe(OnPlayerDeath);
        }

        private void OnPlayerDeath(bool alive)
        {
            if (alive) return;
            _gameOverPopup.SetActive(true);
            _gameManager.GameOver();
        }
    }
}