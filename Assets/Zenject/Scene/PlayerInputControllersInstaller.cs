using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerInputControllersInstaller : MonoInstaller
	{
		[SerializeField] 
		private SceneEntity _character;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PlayerTargetController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerJumpController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerXAxisMovementController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerAttackController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerAbilityController>()
			         .AsSingle()
			         .WithArguments(_character);
		}
	}
}