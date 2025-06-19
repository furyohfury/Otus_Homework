using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	[CreateAssetMenu(fileName = "CursorSystemsInstaller", menuName = "Create installer/UI/CursorSystemsInstaller")]
	public sealed class CursorSystemsInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private CursorSpritesConfig _cursorSpritesConfig;

		public override void InstallBindings()
		{
			Container.Bind<CursorSpritesConfig>()
			         .FromInstance(_cursorSpritesConfig)
			         .AsSingle();

			Container.BindInterfacesTo<CursorImageChanger>()
			         .AsSingle();
		}
	}
}