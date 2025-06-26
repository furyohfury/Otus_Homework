using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "QualitySystemsInstaller", menuName = "Create installer/Quality/QualitySystemsInstaller")]
	public sealed class QualitySystemsInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
#if UNITY_WEBGL
			Container.BindInterfacesAndSelfTo<FramerateSelector>()
			         .AsSingle();
#endif
		}
	}
}