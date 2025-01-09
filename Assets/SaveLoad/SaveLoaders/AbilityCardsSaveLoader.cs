using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SaveLoad
{
	public sealed class AbilityCardsSaveLoader : SaveLoader<IEnumerable<AbilityCardData>, IEntityWorld>
	{
		private readonly SceneEntity _prefab;

		public AbilityCardsSaveLoader(SceneEntity prefab)
		{
			_prefab = prefab;
		}

		protected override IEnumerable<AbilityCardData> ConvertToData(IEntityWorld world)
		{
			IReadOnlyList<IEntity> abilityCards = world.GetEntitiesWithTag(TagAPI.AbilityCard);
			AbilityCardData[] data = new AbilityCardData[abilityCards.Count];

			for (var i = 0; i < data.Length; i++)
			{
				IEntity card = abilityCards[i];
				var transform = card.GetVisualTransform();

				data[i] = new AbilityCardData(card.InstanceId,
					transform.position,
					transform.rotation,
					transform.localScale,
					card.GetAbilityCardGUID());
			}

			return data;
		}

		protected override void SetupData(IEntityWorld world, IEnumerable<AbilityCardData> data)
		{
			foreach (var cardData in data)
			{
				var existingCard = world.Entities.SingleOrDefault(entity => entity.InstanceId == cardData.InstanceID);
				if (existingCard != default)
				{
					SetupExistingCard(existingCard, cardData);
				}
				else
				{
					CreateNewCard(world, cardData);
				}
			}
		}

		private void SetupExistingCard(IEntity existingCard, AbilityCardData cardData)
		{
			var cardTransform = existingCard.GetVisualTransform();
			cardTransform.position = cardData.Position;
			cardTransform.rotation = cardData.Rotation;
			cardTransform.localScale = cardData.Scale;
		}

		private void CreateNewCard(IEntityWorld world, AbilityCardData cardData)
		{
			var pos = cardData.Position;
			var rot = cardData.Rotation;
			SceneEntity newCard = SceneEntityCreator.OnCreateEntityInRoot(_prefab, pos, rot);
			newCard.transform.localScale = cardData.Scale;
			var installer = newCard.GetComponent<AbilityCardInstaller>();
			installer.InstallConfig(newCard, new AssetReference(cardData.AssetGuid));
		}
	}
}