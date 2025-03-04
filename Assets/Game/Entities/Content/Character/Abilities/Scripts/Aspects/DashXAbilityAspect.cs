using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class DashXAbilityAspect : IEntityAspect
	{
		[SerializeField]
		private int _numberOfUses;
		[SerializeField]
		private float _dashForce = 2000f;

		public void Apply(IEntity entity)
		{
			InitAbility(entity);
			InitBehaviours(entity);
		}

		private void InitAbility(IEntity entity)
		{
			entity.AddDashForce(new ReactiveVariable<float>(_dashForce));
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

			entity.AddBehaviour<DashXAbilityBehaviour>();
		}

		public void Discard(IEntity entity)
		{
			entity.DelDashForce();
			entity.DelAbilityUseNumber();
			entity.DelBehaviour<AbilityUseNumberBehaviour>();
			entity.DelBehaviour<AbilityDiscardOnAmmoBehaviour>();
			entity.DelBehaviour<DashXAbilityBehaviour>();
		}
	}
}