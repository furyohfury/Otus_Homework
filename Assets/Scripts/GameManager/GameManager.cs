using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        private List<IGameStateListerner> _iGameStateListeners;
        private List<IOnUpdateListener> _iOnUpdateListeners;
        private List<IOnFixedUpdateListener> _iOnFixedUpdateListeners;

        private IGameState _state;

        private void OnEnable()
        {
            IGameStateListener.OnRegister += RegisterListener;
        }
        private void OnDisable()
        {
            IGameStateListener.OnRegister -= RegisterListener;
        }

        private void Update()
        {
            for(var i = 0; i < _iOnUpdateListeners.Length; i++) //  todo must count state
            {
                _iOnUpdateListeners.OnUpdate();
            }
        }

        private void FixedUpdate()
        {
            for(var i = 0; i < _iOnFixedUpdateListeners.Length; i++)
            {
                _iOnUpdateListeners.OnFixedUpdate();
            }
        }

        private void RegisterListener(IGameStateListerner listener)
        {
            _iGameStateListeners.Add(listener);
            if (listener is IOnUpdateListener onUpdateListener)
            {
                _iOnUpdateListeners.Add(onUpdateListener);
            }
            if (listener is IOnUpdateListener onFixedUpdateListener)
            {
                _iOnFixedUpdateListeners.Add(onUpdateListener);
            }
        }
        
        public void ChangeState(IGameState state)
        {
            _state = state;
        }
    }
}