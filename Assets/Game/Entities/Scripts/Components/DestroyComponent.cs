using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Entities
{
	public sealed class DestroyComponent : IComponent
    {
        public Action OnDestroyed;
        public bool IsDead { get; private set; }
        
        public DestroyComponent()
        {
        }

        public void Destroy()
        {
            IsDead = true;
            OnDestroyed?.Invoke();
        }
    }
}