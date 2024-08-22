using UnityEngine;

public static class AnimatorHash
{
	public static readonly int Death = Animator.StringToHash("Death");
	public static readonly int MeleeAttack = Animator.StringToHash("MeleeAttack");
	public static readonly int RangeAttack = Animator.StringToHash("RangeAttack");
	public static readonly int IsMoving = Animator.StringToHash("IsMoving");
}