/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using Game;
using Atomic.Extensions;

namespace Atomic.Entities
{
    public static class CombatAPI
    {
        ///Keys
        public const int Sword = 7; // SceneEntity
        public const int AttackRequest = 13; // BaseEvent
        public const int AttackEvent = 15; // BaseEvent
        public const int CanAttack = 16; // IExpression<bool>
        public const int Damage = 17; // ReactiveVariable<int>
        public const int FirePoint = 30; // ReactiveVariable<Transform>
        public const int Ammo = 31; // ReactiveVariable<int>
        public const int Weapon = 33; // ReactiveVariable<SceneEntity>
        public const int WeaponContainer = 40; // Transform
        public const int WeaponSpreadAngle = 42; // ReactiveVariable<float>
        public const int AttackTimer = 44; // Timer
        public const int AttackDelay = 45; // ReactiveVariable<float>
        public const int ProjectilePrefab = 47; // ReactiveVariable<SceneEntity>
        public const int AmmoSize = 43; // ReactiveVariable<int>
        public const int EquipWeaponRequest = 50; // BaseEvent<SceneEntity>
        public const int UnequipWeaponRequest = 51; // BaseEvent<SceneEntity>


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
        public static IExpression<bool> GetCanAttack(this IEntity obj) => obj.GetValue<IExpression<bool>>(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanAttack(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(CanAttack, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanAttack(this IEntity obj, IExpression<bool> value) => obj.AddValue(CanAttack, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanAttack(this IEntity obj) => obj.HasValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanAttack(this IEntity obj) => obj.DelValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanAttack(this IEntity obj, IExpression<bool> value) => obj.SetValue(CanAttack, value);

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
        public static ReactiveVariable<Transform> GetFirePoint(this IEntity obj) => obj.GetValue<ReactiveVariable<Transform>>(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetFirePoint(this IEntity obj, out ReactiveVariable<Transform> value) => obj.TryGetValue(FirePoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddFirePoint(this IEntity obj, ReactiveVariable<Transform> value) => obj.AddValue(FirePoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFirePoint(this IEntity obj) => obj.HasValue(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelFirePoint(this IEntity obj) => obj.DelValue(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFirePoint(this IEntity obj, ReactiveVariable<Transform> value) => obj.SetValue(FirePoint, value);

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<SceneEntity> GetWeapon(this IEntity obj) => obj.GetValue<ReactiveVariable<SceneEntity>>(Weapon);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWeapon(this IEntity obj, out ReactiveVariable<SceneEntity> value) => obj.TryGetValue(Weapon, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWeapon(this IEntity obj, ReactiveVariable<SceneEntity> value) => obj.AddValue(Weapon, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWeapon(this IEntity obj) => obj.HasValue(Weapon);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWeapon(this IEntity obj) => obj.DelValue(Weapon);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWeapon(this IEntity obj, ReactiveVariable<SceneEntity> value) => obj.SetValue(Weapon, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetWeaponContainer(this IEntity obj) => obj.GetValue<Transform>(WeaponContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWeaponContainer(this IEntity obj, out Transform value) => obj.TryGetValue(WeaponContainer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWeaponContainer(this IEntity obj, Transform value) => obj.AddValue(WeaponContainer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWeaponContainer(this IEntity obj) => obj.HasValue(WeaponContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWeaponContainer(this IEntity obj) => obj.DelValue(WeaponContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWeaponContainer(this IEntity obj, Transform value) => obj.SetValue(WeaponContainer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetWeaponSpreadAngle(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(WeaponSpreadAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWeaponSpreadAngle(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(WeaponSpreadAngle, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWeaponSpreadAngle(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(WeaponSpreadAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWeaponSpreadAngle(this IEntity obj) => obj.HasValue(WeaponSpreadAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWeaponSpreadAngle(this IEntity obj) => obj.DelValue(WeaponSpreadAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWeaponSpreadAngle(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(WeaponSpreadAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Timer GetAttackTimer(this IEntity obj) => obj.GetValue<Timer>(AttackTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackTimer(this IEntity obj, out Timer value) => obj.TryGetValue(AttackTimer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackTimer(this IEntity obj, Timer value) => obj.AddValue(AttackTimer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackTimer(this IEntity obj) => obj.HasValue(AttackTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackTimer(this IEntity obj) => obj.DelValue(AttackTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackTimer(this IEntity obj, Timer value) => obj.SetValue(AttackTimer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetAttackDelay(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(AttackDelay);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackDelay(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(AttackDelay, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackDelay(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(AttackDelay, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackDelay(this IEntity obj) => obj.HasValue(AttackDelay);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackDelay(this IEntity obj) => obj.DelValue(AttackDelay);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackDelay(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(AttackDelay, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<SceneEntity> GetProjectilePrefab(this IEntity obj) => obj.GetValue<ReactiveVariable<SceneEntity>>(ProjectilePrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetProjectilePrefab(this IEntity obj, out ReactiveVariable<SceneEntity> value) => obj.TryGetValue(ProjectilePrefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddProjectilePrefab(this IEntity obj, ReactiveVariable<SceneEntity> value) => obj.AddValue(ProjectilePrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasProjectilePrefab(this IEntity obj) => obj.HasValue(ProjectilePrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelProjectilePrefab(this IEntity obj) => obj.DelValue(ProjectilePrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetProjectilePrefab(this IEntity obj, ReactiveVariable<SceneEntity> value) => obj.SetValue(ProjectilePrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetAmmoSize(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(AmmoSize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAmmoSize(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(AmmoSize, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAmmoSize(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(AmmoSize, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAmmoSize(this IEntity obj) => obj.HasValue(AmmoSize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAmmoSize(this IEntity obj) => obj.DelValue(AmmoSize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAmmoSize(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(AmmoSize, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<SceneEntity> GetEquipWeaponRequest(this IEntity obj) => obj.GetValue<BaseEvent<SceneEntity>>(EquipWeaponRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetEquipWeaponRequest(this IEntity obj, out BaseEvent<SceneEntity> value) => obj.TryGetValue(EquipWeaponRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddEquipWeaponRequest(this IEntity obj, BaseEvent<SceneEntity> value) => obj.AddValue(EquipWeaponRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEquipWeaponRequest(this IEntity obj) => obj.HasValue(EquipWeaponRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelEquipWeaponRequest(this IEntity obj) => obj.DelValue(EquipWeaponRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEquipWeaponRequest(this IEntity obj, BaseEvent<SceneEntity> value) => obj.SetValue(EquipWeaponRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<SceneEntity> GetUnequipWeaponRequest(this IEntity obj) => obj.GetValue<BaseEvent<SceneEntity>>(UnequipWeaponRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetUnequipWeaponRequest(this IEntity obj, out BaseEvent<SceneEntity> value) => obj.TryGetValue(UnequipWeaponRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddUnequipWeaponRequest(this IEntity obj, BaseEvent<SceneEntity> value) => obj.AddValue(UnequipWeaponRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasUnequipWeaponRequest(this IEntity obj) => obj.HasValue(UnequipWeaponRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelUnequipWeaponRequest(this IEntity obj) => obj.DelValue(UnequipWeaponRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetUnequipWeaponRequest(this IEntity obj, BaseEvent<SceneEntity> value) => obj.SetValue(UnequipWeaponRequest, value);
    }
}
