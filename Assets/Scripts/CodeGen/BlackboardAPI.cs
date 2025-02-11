/**
* Code generation. Don't modify! 
 */
using System.Runtime.CompilerServices;
using Atomic.AI;
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;
namespace Game
{
    public static class BlackboardAPI
    {
        public const int Target = 1; // SceneEntity : class
        public const int AttackRange = 2; // float
        public const int Entity = 3; // SceneEntity : class


        ///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IBlackboard obj) => obj.HasObject(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity  GetTarget(this IBlackboard obj) => obj.GetObject<SceneEntity >(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IBlackboard obj, out SceneEntity  value) => obj.TryGetObject(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IBlackboard obj, SceneEntity  value) => obj.SetObject(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IBlackboard obj) => obj.DelObject(Target);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackRange(this IBlackboard obj) => obj.HasFloat(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetAttackRange(this IBlackboard obj) => obj.GetFloat(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackRange(this IBlackboard obj, out float value) => obj.TryGetFloat(AttackRange, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackRange(this IBlackboard obj, float value) => obj.SetFloat(AttackRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackRange(this IBlackboard obj) => obj.DelFloat(AttackRange);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEntity(this IBlackboard obj) => obj.HasObject(Entity);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity  GetEntity(this IBlackboard obj) => obj.GetObject<SceneEntity >(Entity);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEntity(this IBlackboard obj, out SceneEntity  value) => obj.TryGetObject(Entity, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEntity(this IBlackboard obj, SceneEntity  value) => obj.SetObject(Entity, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEntity(this IBlackboard obj) => obj.DelObject(Entity);

    }
}
