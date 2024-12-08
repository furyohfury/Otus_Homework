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
		private readonly IReactiveList<AbilityCardState> _characterInventory;

		[Inject]
		public AbilityCardInventoryPresenter(AbilityCardInventoryView abilityCardInventoryView, IEntity character)
		{
			_abilityCardInventoryView = abilityCardInventoryView;

			if (!character.TryGetAbilityInventory(out ReactiveList<AbilityCardState> characterInventory))
			{
				throw new NullReferenceException("Presenter cant find ability inventory on character");
			}

			_characterInventory = characterInventory;
		}

		public void Initialize()
		{
			_characterInventory.OnItemInserted += OnCardAdded;
			_characterInventory.OnItemDeleted += OnCardDeleted;
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

		public void Dispose()
		{
			_characterInventory.OnItemInserted -= OnCardAdded;
			_characterInventory.OnItemDeleted -= OnCardDeleted;
		}
	}
}