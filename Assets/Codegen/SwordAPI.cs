/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using Game;
using Atomic.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Atomic.Entities
{
    public static class SwordAPI
    {
        ///Keys
        public const int AttackRotationAngle = 14; // ReactiveVariable<Vector3>
        public const int SlashSpeed = 22; // ReactiveVariable<float>
        public const int ReverseSlashSpeed = 25; // ReactiveVariable<float>
        public const int ActivateColliderEvent = 65; // BaseEvent
        public const int DeactivateColliderEvent = 66; // BaseEvent


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Vector3> GetAttackRotationAngle(this IEntity obj) => obj.GetValue<ReactiveVariable<Vector3>>(AttackRotationAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackRotationAngle(this IEntity obj, out ReactiveVariable<Vector3> value) => obj.TryGetValue(AttackRotationAngle, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackRotationAngle(this IEntity obj, ReactiveVariable<Vector3> value) => obj.AddValue(AttackRotationAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackRotationAngle(this IEntity obj) => obj.HasValue(AttackRotationAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackRotationAngle(this IEntity obj) => obj.DelValue(AttackRotationAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackRotationAngle(this IEntity obj, ReactiveVariable<Vector3> value) => obj.SetValue(AttackRotationAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetSlashSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(SlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSlashSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(SlashSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSlashSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(SlashSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSlashSpeed(this IEntity obj) => obj.HasValue(SlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSlashSpeed(this IEntity obj) => obj.DelValue(SlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSlashSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(SlashSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetReverseSlashSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(ReverseSlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetReverseSlashSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(ReverseSlashSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddReverseSlashSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(ReverseSlashSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasReverseSlashSpeed(this IEntity obj) => obj.HasValue(ReverseSlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelReverseSlashSpeed(this IEntity obj) => obj.DelValue(ReverseSlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetReverseSlashSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(ReverseSlashSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetActivateColliderEvent(this IEntity obj) => obj.GetValue<BaseEvent>(ActivateColliderEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetActivateColliderEvent(this IEntity obj, out BaseEvent value) => obj.TryGetValue(ActivateColliderEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddActivateColliderEvent(this IEntity obj, BaseEvent value) => obj.AddValue(ActivateColliderEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasActivateColliderEvent(this IEntity obj) => obj.HasValue(ActivateColliderEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelActivateColliderEvent(this IEntity obj) => obj.DelValue(ActivateColliderEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetActivateColliderEvent(this IEntity obj, BaseEvent value) => obj.SetValue(ActivateColliderEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetDeactivateColliderEvent(this IEntity obj) => obj.GetValue<BaseEvent>(DeactivateColliderEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDeactivateColliderEvent(this IEntity obj, out BaseEvent value) => obj.TryGetValue(DeactivateColliderEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDeactivateColliderEvent(this IEntity obj, BaseEvent value) => obj.AddValue(DeactivateColliderEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDeactivateColliderEvent(this IEntity obj) => obj.HasValue(DeactivateColliderEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDeactivateColliderEvent(this IEntity obj) => obj.DelValue(DeactivateColliderEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDeactivateColliderEvent(this IEntity obj, BaseEvent value) => obj.SetValue(DeactivateColliderEvent, value);
    }
}
