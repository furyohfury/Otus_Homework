/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using Game;

namespace Atomic.Entities
{
    public static class SwordAPI
    {
        ///Keys
        public const int AttackRotationAngle = 14; // ReactiveVariable<Vector3>
        public const int SlashSpeed = 22; // ReactiveVariable<float>
        public const int RestoreSlashSpeed = 25; // ReactiveVariable<float>


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
        public static ReactiveVariable<float> GetRestoreSlashSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(RestoreSlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRestoreSlashSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(RestoreSlashSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRestoreSlashSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(RestoreSlashSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRestoreSlashSpeed(this IEntity obj) => obj.HasValue(RestoreSlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRestoreSlashSpeed(this IEntity obj) => obj.DelValue(RestoreSlashSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRestoreSlashSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(RestoreSlashSpeed, value);
    }
}
