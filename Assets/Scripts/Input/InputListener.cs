using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputListener : MonoBehaviour
    {
        public event Action OnPlayerFire;
        public float HorizontalDirection {  get; private set; }

        [SerializeField]
        private Player _player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnPlayerFire?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.HorizontalDirection = 1;
            }
            else
            {
                this.HorizontalDirection = 0;
            }
        }
    }
}