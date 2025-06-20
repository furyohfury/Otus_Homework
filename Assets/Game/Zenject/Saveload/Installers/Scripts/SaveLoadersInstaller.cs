using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "SaveLoadersInstaller", menuName = "Create installer/SaveLoadersInstaller")]
	public sealed class SaveLoadersInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private SceneEntity _abilityCardPrefab;
		[SerializeField]
		private AbilityCardConfigs _abilityCardConfigs;
		[SerializeField]
		private EnemyPrefabs _enemyPrefabs;
		[SerializeField]
		private LevelEntitiesPrefabs _levelEntitiesPrefabs;
		[SerializeField]
		private WeaponPrefabs _weaponPrefabs;

		public override void InstallBindings()
		{
			Container.Bind<ISaveLoader>()
			         .To<CharacterSaveLoader>()
			         .AsCached()
			         .WithArguments(_weaponPrefabs.Prefabs);

			Container.Bind<ISaveLoader>()
			         .To<AbilityCardsSaveLoader>()
			         .AsCached()
			         .WithArguments(_abilityCardPrefab, _abilityCardConfigs);

			Container.Bind<ISaveLoader>()
			         .To<LevelResultsSaveLoader>()
			         .AsCached();

			Container.Bind<ISaveLoader>()
			         .To<EnemiesSaveLoader>()
			         .AsCached()
			         .WithArguments(_enemyPrefabs.Prefabs);

			Container.Bind<ISaveLoader>()
			         .To<LevelEntitiesSaveLoader>()
			         .AsCached()
			         .WithArguments(_levelEntitiesPrefabs.Prefabs);
			
			Container.Bind<ISaveLoader>()
			         .To<ProjectilesSaveLoader>()
			         .AsCached();

			Container.Bind<ISaveLoader>()
			         .To<WorldEntitiesSaveLoader>()
			         .AsCached();
		}
	}
}