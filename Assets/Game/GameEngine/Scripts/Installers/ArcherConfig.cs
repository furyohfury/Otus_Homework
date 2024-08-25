using UnityEngine;

[CreateAssetMenu(fileName = "ArcherConfig", menuName = "Create config/Archer config")]
public sealed class ArcherConfig : ScriptableObject
{
	public int Health;
	public float MoveSpeed;
	public float RotationRate;
	public float AttackCooldown;
	public float AttackRange;
}