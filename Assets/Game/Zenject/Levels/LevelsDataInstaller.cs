using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "LevelsDataInstaller", menuName = "Create installer/LevelsDataInstaller")]
	public class LevelsDataInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private LevelConfig[] _cupsTimesConfigs;
		[SerializeField] 
		private PlayfabLevelNames _playfabLevelNames;

		public override void InstallBindings()
		{
			Container.Bind<LevelConfig[]>()
			         .FromInstance(_cupsTimesConfigs)
			         .AsSingle();

			Container.Bind<PlayfabLevelNames>()
			         .FromInstance(_playfabLevelNames)
			         .AsSingle();
			
			// Container.Bind<ILevelsDataService>()
			//          .To<LevelsDataService>()
			//          .AsSingle();

			Container.Bind<ILevelsDataService>()
			         .To<PlayfabLevelsDataService>()
			         .AsSingle();
		}
	}
}