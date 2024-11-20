using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public class SceneInstaller : MonoInstaller
	{
		[SerializeField]
		private SceneEntity _character;
		
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<MovementController>().AsSingle().WithArguments(_character);
		}
	}
}