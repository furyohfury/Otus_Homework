using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class InputListener : ITickable
    {
        public Vector3 Direction { get; private set; }

        public void Tick()
        {
            Direction = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}
