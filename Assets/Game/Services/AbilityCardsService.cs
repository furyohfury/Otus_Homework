using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AbilityCardsService
	{
		public Transform Container => _container;

		private readonly IEntityWorld _entityWorld;
		private readonly Transform _container;

		public AbilityCardsService(IEntityWorld entityWorld, Transform container)
		{
			_entityWorld = entityWorld;
			_container = container;
		}

		public IReadOnlyList<IEntity> GetAbilityCards()
		{
			return _entityWorld.GetEntitiesWithTag(TagAPI.AbilityCard);
		}
	}
}