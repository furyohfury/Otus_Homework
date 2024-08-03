using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class InputListener : MonoBehaviour
    {
        public Vector3 Direction { get; private set; }

        void Update()
        {
            Direction = new (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}
