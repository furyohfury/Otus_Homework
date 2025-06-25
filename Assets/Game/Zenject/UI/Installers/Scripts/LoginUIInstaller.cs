using Zenject;

namespace UI
{
	public sealed class LoginUIInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<LoginUserView>()
			         .FromComponentInHierarchy()
			         .AsSingle();
			
			Container.BindInterfacesAndSelfTo<LoginUserPresenter>()
			         .AsSingle();
		}
	}
}