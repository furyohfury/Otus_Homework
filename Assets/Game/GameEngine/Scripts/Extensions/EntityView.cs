using Entitas.Unity;
using UnityEngine;

public class EntityView : MonoBehaviour
{
	public GameEntity LinkedEntity;

	[SerializeField]
	private EntityInstaller[] installers;

	public bool IsAlive()
	{
		return LinkedEntity.isEnabled;
	}

	public bool IsPoolable = true;

	public void Initialize(GameEntity gameEntity)
	{
		LinkedEntity = gameEntity;

		for (int i = 0, count = installers.Length; i < count; i++)
		{
			var installer = installers[i];
			installer.Install(LinkedEntity);
		}

		gameObject.Link(gameEntity);
	}

	public void Dispose()
	{
		for (int i = 0, count = installers.Length; i < count; i++)
		{
			var installer = installers[i];
			installer.Dispose(LinkedEntity);
		}

		gameObject.Unlink();
	}
}