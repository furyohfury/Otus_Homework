using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game;
using Zenject;

namespace SaveLoad
{
	public sealed class AbilityCardsSaveLoader : SaveLoader<IEnumerable<AbilityCardData>, AbilityCardsService>
	{
		private readonly SceneEntity _prefab;
		private readonly AbilityCardConfigs _abilityCardConfigs;

		[Inject]
		public AbilityCardsSaveLoader(SceneEntity prefab, AbilityCardConfigs abilityCardConfigs)
		{
			_prefab = prefab;
			_abilityCardConfigs = abilityCardConfigs;
		}

		protected override IEnumerable<AbilityCardData> ConvertToData(AbilityCardsService service)
		{
			var abilityCards = service.GetAbilityCards();
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

		protected override void SetupData(AbilityCardsService service, IEnumerable<AbilityCardData> data)
		{
			List<IEntity> sceneCards = service.GetAbilityCards().ToList();
			var dataArray = data.ToArray();

			foreach (IEntity sceneCard in sceneCards)
			{
				bool cardIsSaved = dataArray.Any(cardData => cardData.InstanceID == sceneCard.InstanceId);
				if (cardIsSaved == false)
				{
					DestroyCard(sceneCard);
				}
			}

			foreach (AbilityCardData cardData in dataArray)
			{
				var existingCard = sceneCards.SingleOrDefault(card => card.InstanceId == cardData.InstanceID);
				if (existingCard != default)
				{
					SetupExistingCard(existingCard, cardData);
				}
				else
				{
					CreateNewCard(service, cardData);
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

		private void CreateNewCard(AbilityCardsService service, AbilityCardData cardData)
		{
			var pos = cardData.Position;
			var rot = cardData.Rotation;

			SceneEntity newCard = SceneEntity.Instantiate(_prefab, pos, rot, service.Container);
			newCard.transform.localScale = cardData.Scale;

			var id = cardData.Id;
			var config = _abilityCardConfigs.Configs[id];
			var installer = newCard.GetComponent<AbilityCardInstaller>();
			installer.SetConfig(config);
		}

		private void DestroyCard(IEntity sceneCard)
		{
			SceneEntity.Destroy(sceneCard);
		}
	}
}