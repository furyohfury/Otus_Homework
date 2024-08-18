using UnityEngine;

public abstract class EntityInstaller : MonoBehaviour
{
    protected internal abstract void Install(GameEntity entity);
    protected internal abstract void Dispose(GameEntity entity);
}