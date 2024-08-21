using UnityEngine;
using Zenject;

public class DISystemsInstaller : MonoInstaller
{
	[SerializeField]
	private GameController _gameController;

	public override void InstallBindings()
	{
		Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
	}
}