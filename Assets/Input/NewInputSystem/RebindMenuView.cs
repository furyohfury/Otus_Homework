using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public sealed class RebindMenuView : MonoBehaviour
	{
		[SerializeField]
		private RebindButtonView _rebindButtonViewPrefab;
		[SerializeField]
		private Transform _container;

		public RebindButtonView CreateRebindView()
		{
			return Instantiate(_rebindButtonViewPrefab, _container);
		}
	}
}