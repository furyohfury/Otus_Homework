using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public sealed class AbilityCardInventoryView : MonoBehaviour
	{
		[SerializeField]
		private Transform _container;
		[SerializeField]
		private AbilityCardView _abilityCardViewPrefab;

		private readonly Stack<AbilityCardView> _abilityCardViews = new();

		public void AddAbilityCard(Sprite sprite)
		{
			var newView = Instantiate(_abilityCardViewPrefab, _container);
			newView.SetIcon(sprite);
			_abilityCardViews.Push(newView);
		}

		public void DeleteFirstCard()
		{
			if (_abilityCardViews.Count <= 0)
			{
				return;
			}

			var firstCardView = _abilityCardViews.Pop();
			Destroy(firstCardView.gameObject);
		}
	}
}