using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerInputControllersInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PlayerController>()
			         .AsSingle()
			         .NonLazy();
			
			Container.BindInterfacesAndSelfTo<PlayerTargetController>()
			         .AsSingle();
		}
	}
}