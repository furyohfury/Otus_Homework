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
    public static class CombatAPI
    {
        ///Keys
        public const int Sword = 7; // SceneEntity
        public const int AttackRequest = 13; // BaseEvent
        public const int AttackEvent = 15; // BaseEvent
        public const int CanAttack = 16; // AndExpression
        public const int Damage = 17; // ReactiveVariable<int>
        public const int PistolBulletPrefab = 29; // GameObject
        public const int FirePoint = 30; // Transform
        public const int Ammo = 31; // ReactiveVariable<int>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SceneEntity GetSword(this IEntity obj) => obj.GetValue<SceneEntity>(Sword);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSword(this IEntity obj, out SceneEntity value) => obj.TryGetValue(Sword, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSword(this IEntity obj, SceneEntity value) => obj.AddValue(Sword, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSword(this IEntity obj) => obj.HasValue(Sword);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSword(this IEntity obj) => obj.DelValue(Sword);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSword(this IEntity obj, SceneEntity value) => obj.SetValue(Sword, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetAttackRequest(this IEntity obj) => obj.GetValue<BaseEvent>(AttackRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackRequest(this IEntity obj, out BaseEvent value) => obj.TryGetValue(AttackRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackRequest(this IEntity obj, BaseEvent value) => obj.AddValue(AttackRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackRequest(this IEntity obj) => obj.HasValue(AttackRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackRequest(this IEntity obj) => obj.DelValue(AttackRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackRequest(this IEntity obj, BaseEvent value) => obj.SetValue(AttackRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetAttackEvent(this IEntity obj) => obj.GetValue<BaseEvent>(AttackEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackEvent(this IEntity obj, out BaseEvent value) => obj.TryGetValue(AttackEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackEvent(this IEntity obj, BaseEvent value) => obj.AddValue(AttackEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackEvent(this IEntity obj) => obj.HasValue(AttackEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackEvent(this IEntity obj) => obj.DelValue(AttackEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackEvent(this IEntity obj, BaseEvent value) => obj.SetValue(AttackEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanAttack(this IEntity obj) => obj.GetValue<AndExpression>(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanAttack(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanAttack, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanAttack(this IEntity obj, AndExpression value) => obj.AddValue(CanAttack, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanAttack(this IEntity obj) => obj.HasValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanAttack(this IEntity obj) => obj.DelValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanAttack(this IEntity obj, AndExpression value) => obj.SetValue(CanAttack, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetDamage(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamage(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(Damage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamage(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(Damage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamage(this IEntity obj) => obj.HasValue(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamage(this IEntity obj) => obj.DelValue(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamage(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(Damage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameObject GetPistolBulletPrefab(this IEntity obj) => obj.GetValue<GameObject>(PistolBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetPistolBulletPrefab(this IEntity obj, out GameObject value) => obj.TryGetValue(PistolBulletPrefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddPistolBulletPrefab(this IEntity obj, GameObject value) => obj.AddValue(PistolBulletPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasPistolBulletPrefab(this IEntity obj) => obj.HasValue(PistolBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelPistolBulletPrefab(this IEntity obj) => obj.DelValue(PistolBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetPistolBulletPrefab(this IEntity obj, GameObject value) => obj.SetValue(PistolBulletPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetFirePoint(this IEntity obj) => obj.GetValue<Transform>(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetFirePoint(this IEntity obj, out Transform value) => obj.TryGetValue(FirePoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddFirePoint(this IEntity obj, Transform value) => obj.AddValue(FirePoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFirePoint(this IEntity obj) => obj.HasValue(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelFirePoint(this IEntity obj) => obj.DelValue(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFirePoint(this IEntity obj, Transform value) => obj.SetValue(FirePoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetAmmo(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAmmo(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(Ammo, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAmmo(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(Ammo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAmmo(this IEntity obj) => obj.HasValue(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAmmo(this IEntity obj) => obj.DelValue(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAmmo(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(Ammo, value);
    }
}
