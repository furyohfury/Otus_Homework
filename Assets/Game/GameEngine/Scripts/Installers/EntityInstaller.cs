using UnityEngine;

public abstract class EntityInstaller : MonoBehaviour
{
    public abstract void Install(GameEntity entity);
    public abstract void Dispose(GameEntity entity);
}