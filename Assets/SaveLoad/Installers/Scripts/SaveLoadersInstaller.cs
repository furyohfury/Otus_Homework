using UnityEngine;
using Zenject;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "SaveLoadersInstaller", menuName = "Create installer/SaveLoadersInstaller")]
	public sealed class SaveLoadersInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<ISaveLoader>()
			         .To<SceneEntitiesSaveLoader>()
			         .AsCached();
		}
	}
}