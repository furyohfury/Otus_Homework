using Entitas;
using UnityEngine;

[Game]
public class RangeWeaponComponent : IComponent
{
    public Transform FirePoint;
    public EntityView ProjectilePrefab;
}

[Game]
public class FireRequestComponent : IComponent // TODO in separate class
{
}

[Game]
public class SpawnRequestComponent : IComponent
{    
}

[Game]
public class PrefabComponent : IComponent
{
    public EntityView Value;
}