using Entitas.Unity;
using UnityEngine;

public class EntityView : MonoBehaviour
{
    [SerializeField]
    private EntityInstaller[] installers;

    // private GameContext _gameContext;

    public GameEntity LinkedEntity;

    public bool IsAlive() => LinkedEntity.isEnabled;

    // public void Initialize(GameContext context)
    // {
    //     var entity = context.CreateEntity();
    //     Initialize(entity, context);
    // }

    public void Initialize(GameEntity gameEntity)
    {
        LinkedEntity = gameEntity;

        for (int i = 0, count = installers.Length; i < count; i++)
        {
            var installer = installers[i];
            installer.Install(LinkedEntity);
        }
        LinkedEntity.Retain(this);
        gameObject.Link(gameEntity);
    }

    public void Dispose()
    {
        for (int i = 0, count = installers.Length; i < count; i++)
        {
            var installer = installers[i];
            installer.Dispose(LinkedEntity);
        }
        LinkedEntity.Release(this);
        gameObject.Unlink();
    }
}