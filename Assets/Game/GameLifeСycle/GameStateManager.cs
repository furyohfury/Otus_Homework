using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class GameStateManager
    {
        public event Action<GameState> OnStateChanged;
        
        public GameState State => _state;
        
        private GameState _state;

        public void ChangeState(GameState state)
        {
            _state = state;
            OnStateChanged?.Invoke(state);
        }
    }

    public enum GameState
    {
        Start,
        Pause,
        Resume,
        Finish
    }
}