using System;

namespace Entities
{
	public sealed class DestroyComponent : IComponent
	{
		public Action OnDestroyed;
		public bool IsDead { get; private set; }

		public void Destroy()
		{
			IsDead = true;
			OnDestroyed?.Invoke();
		}
	}
}