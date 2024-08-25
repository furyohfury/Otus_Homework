using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanConfig", menuName = "Create config/Swordsman config")]
public sealed class SwordsmanConfig : ScriptableObject
{
	public int Health;
	public float MoveSpeed;
	public float AttackCooldown;
	public float AttackRange;
	public int Damage;
}