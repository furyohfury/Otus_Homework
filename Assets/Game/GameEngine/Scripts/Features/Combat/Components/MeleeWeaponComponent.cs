using Entitas;
using UnityEngine;

[Game]
public class MeleeWeaponComponent : IComponent
{
	public Collider HitBox; // easier to enable/disable in installer than bring it in ecs systems
	public int Damage;
}