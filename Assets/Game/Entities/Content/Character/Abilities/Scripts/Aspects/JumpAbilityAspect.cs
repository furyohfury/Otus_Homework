using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class JumpAbilityAspect : IEntityAspect
	{
		[SerializeField]
		private int _numberOfUses;

		public void Apply(IEntity entity)
		{
			InitAbility(entity);
			InitBehaviours(entity);
		}

		private void InitAbility(IEntity entity)
		{
			entity.AddAbilityUseNumber(new ReactiveVariable<int>(_numberOfUses));
		}

		private void InitBehaviours(IEntity entity)
		{
			if (!entity.HasBehaviour<AbilityUseNumberBehaviour>())
			{
				entity.AddBehaviour<AbilityUseNumberBehaviour>();
			}

			if (!entity.HasBehaviour<AbilityDiscardOnAmmoBehaviour>())
			{
				entity.AddBehaviour<AbilityDiscardOnAmmoBehaviour>();
			}

			entity.AddBehaviour<JumpAbilityBehaviour>();
		}

		public void Discard(IEntity entity)
		{
			entity.DelAbilityUseNumber();
			entity.DelBehaviour<AbilityUseNumberBehaviour>();
			entity.DelBehaviour<AbilityDiscardOnAmmoBehaviour>();
			entity.DelBehaviour<JumpAbilityBehaviour>();
		}
	}
}