using Entitas;
using UnityEngine;

[Game]
public class DirectionComponent : IComponent // TODO rename into rotation and add rotate rate mb
{
    public Quaternion Value;
}