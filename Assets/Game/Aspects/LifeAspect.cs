using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class LifeAspect : IEntityAspect
	{
		[SerializeField]
		private int _health;

		public void Apply(IEntity entity)
		{
			entity.AddHealth(_health);
			entity.AddIsDead(new BaseFunction<bool>(() => entity.GetHealth().Value <= 0));
			entity.AddTakeDamageRequest(new BaseEvent<int>());
			entity.AddTakeDamageEvent(new BaseEvent<int>());
			entity.AddCanTakeDamage(new AndExpression());

			entity.AddBehaviour(new TakeDamageRequestBehaviour());
			entity.AddBehaviour(new TakeDamageEventBehaviour());
		}

		public void Discard(IEntity entity)
		{
			entity.DelHealth();
			entity.DelIsDead();
			entity.DelTakeDamageRequest();
			entity.DelTakeDamageEvent();

			entity.DelBehaviour<TakeDamageRequestBehaviour>();
			entity.DelBehaviour<TakeDamageEventBehaviour>();
		}
	}
}