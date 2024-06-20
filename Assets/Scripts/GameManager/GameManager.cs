using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        private List<IGameStateListener> _iGameStateListeners = new();
        private List<IOnUpdateListener> _iOnUpdateListeners = new();
        private List<IOnFixedUpdateListener> _iOnFixedUpdateListeners = new();

        private IGameState _state;

        private bool _activeUpdates = false;

        private void Awake()
        {
            IGameStateListener.OnRegister += RegisterListener;
        }
        private void OnDestroy()
        {
            IGameStateListener.OnRegister -= RegisterListener;
        }

        private void Update()
        {
            if (!_activeUpdates || _iOnUpdateListeners.Count <= 0) 
                return;

            for(var i = 0; i < _iOnUpdateListeners.Count; i++)
            {
                _iOnUpdateListeners[i].OnUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (!_activeUpdates) return;

            for(var i = 0; i < _iOnFixedUpdateListeners.Count; i++)
            {
                _iOnFixedUpdateListeners[i].OnFixedUpdate();
            }
        }

        private void RegisterListener(IGameStateListener listener)
        {
            _iGameStateListeners.Add(listener);
            if (listener is IOnUpdateListener onUpdateListener)
            {
                _iOnUpdateListeners.Add(onUpdateListener);
            }
            if (listener is IOnFixedUpdateListener onFixedUpdateListener)
            {
                _iOnFixedUpdateListeners.Add(onFixedUpdateListener);
            }
        }
        
        public void ChangeState(IGameState state)
        {
            _state = state;
            _activeUpdates = state.ActiveUpdates;
        }

        public void HandleState() => _state.HandleState(_iGameStateListeners);
    }
}