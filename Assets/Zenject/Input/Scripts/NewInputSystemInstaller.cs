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

			Container.Bind<InputControls>()
			         .AsSingle();

			Container.Bind(typeof(IInitializable), typeof(InputRebinder))
			         .To<GamepadInputRebinder>()
			         .AsCached()
			         .NonLazy();

			Container.Bind<BindPathService>()
			         .AsSingle();

			Container.Bind<IRebindSaveLoader>()
			         .To<RebindSaveLoader>()
			         .AsCached();
		}
	}
}