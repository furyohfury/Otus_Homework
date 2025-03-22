using System.Linq;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class InputSystemUIInstaller : MonoInstaller
	{
		[Header("Xbox gamepad")] [SerializeField]
		private RebindMenuView _xboxGamepadRebindMenuView;
		[SerializeField]
		private InputRebindMenuConfig _xboxGamepadRebindMenuConfig;

		[Header("Keyboard")] [SerializeField]
		private RebindMenuView _keyboardRebindMenuView;
		[SerializeField]
		private InputRebindMenuConfig _keyboardRebindMenuConfig;

		private XboxGamepadInputRebinder _xboxGamepadInputRebinder;
		private KeyboardInputRebinder _keyboardInputRebinder;
		
		[Inject]
		public void Construct (XboxGamepadInputRebinder xboxGamepadInputRebinder, KeyboardInputRebinder keyboardInputRebinder)
		{
			_xboxGamepadInputRebinder = xboxGamepadInputRebinder;
			_keyboardInputRebinder = keyboardInputRebinder;
		}

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<RebindMenuPresenter>()
			         .AsCached()
			         .WithArguments(_xboxGamepadRebindMenuConfig, _xboxGamepadRebindMenuView, _xboxGamepadInputRebinder);

			Container.BindInterfacesAndSelfTo<RebindMenuPresenter>()
			         .AsCached()
			         .WithArguments(_keyboardRebindMenuConfig, _keyboardRebindMenuView, _keyboardInputRebinder);
		}
	}
}