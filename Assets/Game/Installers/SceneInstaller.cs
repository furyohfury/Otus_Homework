using UnityEngine;
using Zenject;


public class SceneInstaller : MonoInstaller
{
	[SerializeField]
	private ConveyorModel _conveyorModel;

	public override void InstallBindings()
	{
		Container.Bind<ConveyorModel>().FromInstance(_conveyorModel).AsSingle();
	}
}