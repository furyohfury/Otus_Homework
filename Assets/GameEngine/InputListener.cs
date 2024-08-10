using Atomic.Elements;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class InputListener : ITickable
    {
        public Vector3 Direction { get; private set; }
        public AtomicEvent ShootRequest = new();

        public void Tick()
        {
            Direction = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetMouseButtonDown(0))
            {
                ShootRequest?.Invoke();
            }
        }
    }
}
