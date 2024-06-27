using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputListener : MonoBehaviour, IOnUpdateListener
    {
        public event Action OnFireButton;

        public float HorizontalDirection {  get; private set; }

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        public void OnUpdate(float delta)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireButton?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                HorizontalDirection = 1;
            }
            else
            {
                HorizontalDirection = 0;
            }
        }
    }
}