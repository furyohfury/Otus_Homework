using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerInputControllersInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			// Container.BindInterfacesAndSelfTo<PlayerJumpController>()
			//          .AsSingle()
			//          .WithArguments(_character);
			//
			// Container.BindInterfacesAndSelfTo<PlayerXAxisMovementController>()
			//          .AsSingle()
			//          .WithArguments(_character);
			//
			// Container.BindInterfacesAndSelfTo<PlayerAttackController>()
			//          .AsSingle()
			//          .WithArguments(_character);
			//
			// Container.BindInterfacesAndSelfTo<PlayerAbilityController>()
			//          .AsSingle()
			//          .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerController>()
			         .AsSingle()
			         .NonLazy();
			
			Container.BindInterfacesAndSelfTo<PlayerTargetController>()
			         .AsSingle();
		}
	}
}