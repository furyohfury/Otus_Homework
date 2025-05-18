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
        public const int Target = 1; // Transform : class
        public const int AttackRange = 2; // float
        public const int Waypoints = 3; // Transform[] : class
        public const int Entity = 4; // SceneEntity : class
        public const int WaypointIndex = 5; // int
        public const int StoppingDistance = 6; // float
        public const int DetectRange = 7; // float


        ///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IBlackboard obj) => obj.HasObject(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform  GetTarget(this IBlackboard obj) => obj.GetObject<Transform >(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IBlackboard obj, out Transform  value) => obj.TryGetObject(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IBlackboard obj, Transform  value) => obj.SetObject(Target, value);

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
		public static bool HasWaypoints(this IBlackboard obj) => obj.HasObject(Waypoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform[]  GetWaypoints(this IBlackboard obj) => obj.GetObject<Transform[] >(Waypoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWaypoints(this IBlackboard obj, out Transform[]  value) => obj.TryGetObject(Waypoints, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWaypoints(this IBlackboard obj, Transform[]  value) => obj.SetObject(Waypoints, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWaypoints(this IBlackboard obj) => obj.DelObject(Waypoints);


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


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWaypointIndex(this IBlackboard obj) => obj.HasInt(WaypointIndex);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWaypointIndex(this IBlackboard obj) => obj.GetInt(WaypointIndex);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWaypointIndex(this IBlackboard obj, out int value) => obj.TryGetInt(WaypointIndex, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWaypointIndex(this IBlackboard obj, int value) => obj.SetInt(WaypointIndex, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWaypointIndex(this IBlackboard obj) => obj.DelInt(WaypointIndex);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasStoppingDistance(this IBlackboard obj) => obj.HasFloat(StoppingDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetStoppingDistance(this IBlackboard obj) => obj.GetFloat(StoppingDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetStoppingDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(StoppingDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetStoppingDistance(this IBlackboard obj, float value) => obj.SetFloat(StoppingDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelStoppingDistance(this IBlackboard obj) => obj.DelFloat(StoppingDistance);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDetectRange(this IBlackboard obj) => obj.HasFloat(DetectRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetDetectRange(this IBlackboard obj) => obj.GetFloat(DetectRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDetectRange(this IBlackboard obj, out float value) => obj.TryGetFloat(DetectRange, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDetectRange(this IBlackboard obj, float value) => obj.SetFloat(DetectRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDetectRange(this IBlackboard obj) => obj.DelFloat(DetectRange);

    }
}
