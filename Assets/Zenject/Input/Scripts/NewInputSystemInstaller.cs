using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "NewInputSystemInstaller", menuName = "Create installer/NewInputSystem installer")]
	public sealed class NewInputSystemInstaller : ScriptableObjectInstaller
	{

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<InputReader>()
			         .AsSingle();

			Container.Bind<InputControls>()
			         .AsSingle();

			Container.Bind<InputRebinder>()
			         .To<KeyboardInputRebinder>()
			         .AsCached()
			         .NonLazy();
		}
	}
}