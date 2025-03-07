using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "GameLifeCycleInstaller", menuName = "Create installer/GameLifeCycleInstaller")]
	public sealed class GameLifeCycleInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<GameStateManager>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<GameLauncher>()
			         .AsCached()
			         .NonLazy();
		}
	}
}