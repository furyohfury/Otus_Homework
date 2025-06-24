using Zenject;

namespace Game
{
	public sealed class PlayerInputControllersInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PlayerController>()
			         .AsSingle()
			         ;

			Container.BindInterfacesAndSelfTo<PlayerTargetController>()
			         .AsSingle();
		}
	}
}