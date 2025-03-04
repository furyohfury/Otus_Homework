using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "InputInstaller", menuName = "Create installer/Input installer")]
	public sealed class InputInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private InputMap _inputMap;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<InputListener>()
			         .AsSingle()
			         .WithArguments(_inputMap);
		}
	}
}