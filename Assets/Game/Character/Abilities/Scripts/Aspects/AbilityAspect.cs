using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using Game;
using UnityEngine;

[Serializable]
public sealed class AbilityAspect : IEntityAspect // TODO delete
{
	[SerializeField]
	private int _numberOfUses;
	[SerializeReference]
	private IEntityBehaviour[] _abilityBehaviours;

	public void Apply(IEntity entity)
	{
		InitAbility(entity);
		InitBehaviours(entity);
	}

	private void InitAbility(IEntity entity)
	{
		entity.AddAbilityUseNumber(new ReactiveVariable<int>(_numberOfUses));
		// if (!entity.AddActiveAbilityAspect(new ReactiveVariable<IEntityAspect>(this)))
		// {
		// 	entity.GetActiveAbilityAspect().Value = this;
		// }
	}

	private void InitBehaviours(IEntity entity)
	{
		foreach (var ability in _abilityBehaviours)
		{
			entity.AddBehaviour(ability);
		}

		if (!entity.HasBehaviour<AbilityUseNumberBehaviour>())
		{
			entity.AddBehaviour<AbilityUseNumberBehaviour>();
		}

		if (!entity.HasBehaviour<AbilityDiscardOnAmmoBehaviour>())
		{
			entity.AddBehaviour<AbilityDiscardOnAmmoBehaviour>();
		}
	}

	public void Discard(IEntity entity)
	{
		entity.DelAbilityUseNumber();

		foreach (var ability in _abilityBehaviours)
		{
			entity.DelBehaviour(ability);
		}

		entity.DelBehaviour<AimWeaponBehaviour>();
		entity.DelBehaviour<AbilityUseNumberBehaviour>();
		entity.DelBehaviour<AbilityDiscardOnAmmoBehaviour>();
	}
}