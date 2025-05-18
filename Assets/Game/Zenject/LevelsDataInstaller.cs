using UnityEngine;
using Zenject;

namespace Game
{
	public class LevelsDataInstaller : MonoInstaller
	{
		[SerializeField]
		private LevelConfig[] _cupsTimesConfigs;

		public override void InstallBindings()
		{
			Container.Bind<LevelConfig[]>()
			         .FromInstance(_cupsTimesConfigs)
			         .AsSingle();

			Container.Bind<LevelsDataService>()
			         .AsSingle();
		}
	}
}