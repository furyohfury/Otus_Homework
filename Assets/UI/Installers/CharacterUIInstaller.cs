using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class CharacterUIInstaller : MonoInstaller
	{
		[SerializeField]
		private SceneEntity _character;
		[SerializeField]
		private SingleTextFieldView _healthView;
		[SerializeField]
		private SingleTextFieldView _ammoView;
		[SerializeField]
		private AbilityCardInventoryView _abilityCardInventoryView;

		public override void InstallBindings()
		{
			Container.BindInterfacesTo<CharacterHealthPresenter>()
			         .AsCached()
			         .WithArguments(_healthView, _character);
			Container.BindInterfacesTo<CharacterAmmoPresenter>()
			         .AsCached()
			         .WithArguments(_ammoView, _character);
			Container.BindInterfacesTo<AbilityCardInventoryPresenter>()
			         .AsCached()
			         .WithArguments(_abilityCardInventoryView, _character);
		}
	}
}