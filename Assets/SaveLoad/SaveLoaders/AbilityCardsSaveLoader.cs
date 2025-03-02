using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
	public sealed class AbilityCardsSaveLoader : SaveLoader<IEnumerable<AbilityCardData>, IEntityWorld>
	{
		private readonly SceneEntity _prefab;
		private readonly AbilityCardConfigs _abilityCardConfigs;

		[Inject]
		public AbilityCardsSaveLoader(SceneEntity prefab, AbilityCardConfigs abilityCardConfigs)
		{
			_prefab = prefab;
			_abilityCardConfigs = abilityCardConfigs;
		}

		protected override IEnumerable<AbilityCardData> ConvertToData(IEntityWorld world)
		{
			IReadOnlyList<IEntity> abilityCards = world.GetEntitiesWithTag(TagAPI.AbilityCard);
			AbilityCardData[] data = new AbilityCardData[abilityCards.Count];

			for (var i = 0; i < data.Length; i++)
			{
				IEntity card = abilityCards[i];
				var config = card.GetAbilityCardConfig();
				var transform = card.GetVisualTransform();

				data[i] = new AbilityCardData(card.InstanceId,
					config.Value.Id,
					transform.position,
					transform.rotation,
					transform.localScale);
			}

			return data;
		}

		protected override void SetupData(IEntityWorld world, IEnumerable<AbilityCardData> data)
		{
			AbilityCardData[] dataArray = data.ToArray();
			IEntity[] sceneCards = world.GetEntitiesWithTag(TagAPI.AbilityCard).ToArray();

			Dictionary<int, AbilityCardData> savedCardsDict = dataArray.ToDictionary(cardData => cardData.InstanceID);
			Dictionary<int, IEntity> sceneCardsDict = sceneCards.ToDictionary(entity => entity.InstanceId);

			foreach (var cardData in dataArray)
			{
				if (sceneCardsDict.TryGetValue(cardData.InstanceID, out IEntity existingCard))
				{
					SetupExistingCard(existingCard, cardData);
				}
				else
				{
					CreateNewCard(world, cardData);
				}
			}

			foreach (IEntity sceneCard in sceneCards)
			{
				if (!savedCardsDict.ContainsKey(sceneCard.InstanceId))
				{
					SceneEntity.Destroy(sceneCard);
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
			if (world is SceneEntityWorld sceneEntityWorld)	
			{
				SceneEntity newCard = SceneEntity.Instantiate(_prefab, pos, rot, sceneEntityWorld.transform);
				newCard.transform.localScale = cardData.Scale;

				var id = cardData.Id;
				var config = _abilityCardConfigs.Configs[id];
				var installer = newCard.GetComponent<AbilityCardInstaller>();
				installer.SetConfig(config);
			}
		}
	}
}