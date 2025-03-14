using System;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class AbilityCardInventoryPresenter : IInitializable, IDisposable
	{
		private readonly AbilityCardInventoryView _abilityCardInventoryView;
		private readonly ReactiveList<AbilityCardState> _characterInventory;
		private readonly PlayerService _playerService;

		[Inject]
		public AbilityCardInventoryPresenter(AbilityCardInventoryView abilityCardInventoryView, PlayerService playerService)
		{
			_abilityCardInventoryView = abilityCardInventoryView;
			_playerService = playerService;

			if (!_playerService.Player.TryGetAbilityInventory(out ReactiveList<AbilityCardState> characterInventory))
			{
				throw new NullReferenceException("Presenter cant find ability inventory on character");
			}

			_characterInventory = characterInventory;
		}

		public void Initialize()
		{
			_characterInventory.OnItemInserted += OnCardAdded;
			_characterInventory.OnItemDeleted += OnCardDeleted;
			_characterInventory.OnCleared += OnCardsCleared;
		}

		private void OnCardAdded(int index, AbilityCardState state)
		{
			Sprite sprite = state.Config.Sprite;
			_abilityCardInventoryView.AddAbilityCard(sprite);
		}

		private void OnCardDeleted(int index, AbilityCardState value)
		{
			_abilityCardInventoryView.DeleteFirstCard();
		}

		private void OnCardsCleared()
		{
			_abilityCardInventoryView.ClearAllCards();
		}

		public void Dispose()
		{
			_characterInventory.OnItemInserted -= OnCardAdded;
			_characterInventory.OnItemDeleted -= OnCardDeleted;
		}
	}
}