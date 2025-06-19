using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class CharacterUIInstaller : MonoInstaller
	{
		[SerializeField]
		private AmountView _healthView;
		[SerializeField]
		private AmountView _ammoView;
		[SerializeField]
		private AbilityCardInventoryView _abilityCardInventoryView;

		public override void InstallBindings()
		{
			Container.BindInterfacesTo<CharacterHealthPresenter>()
			         .AsCached()
			         .WithArguments(_healthView);
			Container.BindInterfacesTo<CharacterAmmoPresenter>()
			         .AsCached()
			         .WithArguments(_ammoView);
			Container.BindInterfacesTo<AbilityCardInventoryPresenter>()
			         .AsCached()
			         .WithArguments(_abilityCardInventoryView);
		}
	}
}