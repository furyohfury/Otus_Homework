using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace UI
{
	public sealed class AbilityCardInventoryView : MonoBehaviour // TODO unnecessary fade removal animation
	{
		[SerializeField]
		private Transform _container;
		[SerializeField]
		private AbilityCardView _abilityCardViewPrefab;
		[SerializeField]
		private float _cardDestroyAnimationDuration = 0.5f;

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

			AbilityCardView firstCardView = _abilityCardViews.Pop();
			firstCardView.IgnoreLayout(true);
			var cardTransform = firstCardView.transform;
			DOTween.Sequence()
			       .Append(cardTransform.DOMoveY(cardTransform.position.y + 50, _cardDestroyAnimationDuration))
			       .SetEase(Ease.OutExpo)
			       .Join(firstCardView.Icon.DOFade(0, _cardDestroyAnimationDuration))
			       .OnComplete(() => Destroy(firstCardView.gameObject));
		}

		public void ClearAllCards()
		{
			for (var i = 0; i < _abilityCardViews.Count; i++)
			{
				Destroy(_abilityCardViews.Pop().gameObject);
			}
		}
	}
}