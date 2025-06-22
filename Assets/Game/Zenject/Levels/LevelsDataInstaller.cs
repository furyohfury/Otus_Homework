using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "LevelsDataInstaller", menuName = "Create installer/LevelsDataInstaller")]
	public class LevelsDataInstaller : ScriptableObjectInstaller
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