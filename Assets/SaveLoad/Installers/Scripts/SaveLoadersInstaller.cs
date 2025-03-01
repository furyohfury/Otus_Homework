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

		public override void InstallBindings()
		{
			Container.Bind<ISaveLoader>()
			         .To<CharacterSaveLoader>()
			         .AsCached();

			// Container.Bind<ISaveLoader>()
			//          .To<AbilityCardsSaveLoader>()
			//          .AsCached()
			//          .WithArguments(_abilityCardPrefab);

			Container.Bind<ISaveLoader>()
			         .To<LevelResultsSaveLoader>()
			         .AsCached();
		}
	}
}