using Entitas;
using UnityEngine;

[Game]
public class PositionComponent : IComponent
{
    public Vector3 Value;
}

[Game]
public class DirectionComponent : IComponent
{
    public Quaternion Value;
}

[Game]
public class MoveSpeedComponent : IComponent
{
    public float Value;
}

[Game]
public class MoveDirectionComponent : IComponent
{
    public Vector3 Value;
}

[Game]
public class TransformViewComponent : IComponent
{
    public Transform Value;
}

[Game]
public class HealthComponent : IComponent
{
    public int Value;
}

[Game]
public class TeamComponent : IComponent
{
    public Team Value;
}

[Game]
public class SpeedComponent : IComponent
{
    public float Value;
}

[Game]
public class AttackTimerComponent : IComponent
{
    public float Value;
}

[Game]
public class AttackRangeComponent : IComponent
{
    public float Value;
}

[Game]
public class SpawnRequestComponent : IComponent { }