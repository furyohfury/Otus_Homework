using Entitas;
using UnityEngine;

[Game]
public class RangeWeaponComponent : IComponent
{
    public Transform FirePoint;
    public EntityView ProjectilePrefab;
}