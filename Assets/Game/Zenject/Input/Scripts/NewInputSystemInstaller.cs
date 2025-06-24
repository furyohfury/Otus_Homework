using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "NewInputSystemInstaller", menuName = "Create installer/NewInputSystem installer")]
	public sealed class NewInputSystemInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<InputReader>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<GameplayPauseController>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<UIInputReader>()
			         .AsSingle();

			Container.Bind<InputControls>()
			         .AsSingle();

			Container.Bind(typeof(IInitializable), typeof(XboxGamepadInputRebinder))
			         .To<XboxGamepadInputRebinder>()
			         .AsCached()
			         ;

			Container.Bind(typeof(IInitializable), typeof(KeyboardInputRebinder))
			         .To<KeyboardInputRebinder>()
			         .AsCached()
			         ;

			Container.Bind<BindPathService>()
			         .AsSingle();

			Container.Bind<IRebindSaveLoader>()
			         .To<RebindSaveLoader>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<InputMapsStateSwitcher>()
			         .AsSingle();
		}
	}
}