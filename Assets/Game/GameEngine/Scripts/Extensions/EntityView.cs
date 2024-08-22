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

    // public void AddData<T>(T component) where T : struct
    // {
    //     var pool = this.world.GetPool<T>();
    //     pool.Add(Id) = component;
    // }
    //
    // public void RemoveData<T>() where T : struct
    // {
    //     var pool = this.world.GetPool<T>();
    //     pool.Del(Id);
    // }
    //
    // public ref T GetData<T>() where T : struct
    // {
    //     EcsPool<T> pool = this.world.GetPool<T>();
    //     return ref pool.Get(Id);
    // }
    //
    // public void SetData<T>(T data) where T : struct
    // {
    //     var pool = this.world.GetPool<T>();
    //     if (pool.Has(Id))
    //         pool.Get(Id) = data;
    //     else
    //         pool.Add(Id) = data;
    // }
    //
    // public bool TryGetData<T>(out T data) where T : struct
    // {
    //     var pool = this.world.GetPool<T>();
    //     if (pool.Has(Id))
    //     {
    //         data = pool.Get(Id);
    //         return true;
    //     }
    //
    //     data = default;
    //     return false;
    // }
    //
    // public bool HasData<T>() where T : struct
    // {
    //     var pool = this.world.GetPool<T>();
    //     return pool.Has(Id);
    // }
    //
    // public int GetComponentsNonAlloc(ref object[] components)
    // {
    //     return this.world.GetComponents(Id, ref components);
    // }
    //
    // public EcsWorld GetWorld()
    // {
    //     return this.world;
    // }
}