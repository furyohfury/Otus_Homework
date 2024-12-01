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
        public const int Weapon = 33; // ReactiveVariable<GameObject>
        public const int WeaponContainer = 40; // Transform
        public const int RifleBulletPrefab = 41; // GameObject
        public const int MachineGunSpreadAngle = 42; // ReactiveVariable<float>
        public const int MachineGunBulletPrefab = 43; // GameObject
        public const int AttackTimer = 44; // Timer
        public const int AttackDelay = 45; // ReactiveVariable<float>


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<GameObject> GetWeapon(this IEntity obj) => obj.GetValue<ReactiveVariable<GameObject>>(Weapon);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWeapon(this IEntity obj, out ReactiveVariable<GameObject> value) => obj.TryGetValue(Weapon, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWeapon(this IEntity obj, ReactiveVariable<GameObject> value) => obj.AddValue(Weapon, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWeapon(this IEntity obj) => obj.HasValue(Weapon);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWeapon(this IEntity obj) => obj.DelValue(Weapon);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWeapon(this IEntity obj, ReactiveVariable<GameObject> value) => obj.SetValue(Weapon, value);

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
        public static GameObject GetRifleBulletPrefab(this IEntity obj) => obj.GetValue<GameObject>(RifleBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRifleBulletPrefab(this IEntity obj, out GameObject value) => obj.TryGetValue(RifleBulletPrefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRifleBulletPrefab(this IEntity obj, GameObject value) => obj.AddValue(RifleBulletPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRifleBulletPrefab(this IEntity obj) => obj.HasValue(RifleBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRifleBulletPrefab(this IEntity obj) => obj.DelValue(RifleBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRifleBulletPrefab(this IEntity obj, GameObject value) => obj.SetValue(RifleBulletPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetMachineGunSpreadAngle(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(MachineGunSpreadAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMachineGunSpreadAngle(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(MachineGunSpreadAngle, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMachineGunSpreadAngle(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(MachineGunSpreadAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMachineGunSpreadAngle(this IEntity obj) => obj.HasValue(MachineGunSpreadAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMachineGunSpreadAngle(this IEntity obj) => obj.DelValue(MachineGunSpreadAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMachineGunSpreadAngle(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(MachineGunSpreadAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameObject GetMachineGunBulletPrefab(this IEntity obj) => obj.GetValue<GameObject>(MachineGunBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMachineGunBulletPrefab(this IEntity obj, out GameObject value) => obj.TryGetValue(MachineGunBulletPrefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMachineGunBulletPrefab(this IEntity obj, GameObject value) => obj.AddValue(MachineGunBulletPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMachineGunBulletPrefab(this IEntity obj) => obj.HasValue(MachineGunBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMachineGunBulletPrefab(this IEntity obj) => obj.DelValue(MachineGunBulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMachineGunBulletPrefab(this IEntity obj, GameObject value) => obj.SetValue(MachineGunBulletPrefab, value);

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
    }
}
