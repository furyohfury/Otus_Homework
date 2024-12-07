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
    public static class AbilityAPI
    {
        ///Keys
        public const int AbilityRequest = 36; // BaseEvent
        public const int AbilityEvent = 37; // BaseEvent
        public const int DashForce = 38; // ReactiveVariable<float>
        public const int StickyBombPrefab = 46; // SceneEntity
        public const int AbilityUseNumber = 29; // ReactiveVariable<int>
        public const int ActiveAbilityAspects = 41; // ReactiveVariable<IEntityAspect[]>
        public const int ApplyAbilityAspectRequest = 48; // BaseEvent<IEntityAspect>
        public const int AbilityCardPickupEvent = 53; // BaseEvent<AbilityCardConfig>
        public const int AbilityCardConfig = 54; // ReactiveVariable<AbilityCardConfig>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetAbilityRequest(this IEntity obj) => obj.GetValue<BaseEvent>(AbilityRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAbilityRequest(this IEntity obj, out BaseEvent value) => obj.TryGetValue(AbilityRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAbilityRequest(this IEntity obj, BaseEvent value) => obj.AddValue(AbilityRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAbilityRequest(this IEntity obj) => obj.HasValue(AbilityRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAbilityRequest(this IEntity obj) => obj.DelValue(AbilityRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAbilityRequest(this IEntity obj, BaseEvent value) => obj.SetValue(AbilityRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetAbilityEvent(this IEntity obj) => obj.GetValue<BaseEvent>(AbilityEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAbilityEvent(this IEntity obj, out BaseEvent value) => obj.TryGetValue(AbilityEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAbilityEvent(this IEntity obj, BaseEvent value) => obj.AddValue(AbilityEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAbilityEvent(this IEntity obj) => obj.HasValue(AbilityEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAbilityEvent(this IEntity obj) => obj.DelValue(AbilityEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAbilityEvent(this IEntity obj, BaseEvent value) => obj.SetValue(AbilityEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetDashForce(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(DashForce);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDashForce(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(DashForce, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDashForce(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(DashForce, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDashForce(this IEntity obj) => obj.HasValue(DashForce);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDashForce(this IEntity obj) => obj.DelValue(DashForce);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDashForce(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(DashForce, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SceneEntity GetStickyBombPrefab(this IEntity obj) => obj.GetValue<SceneEntity>(StickyBombPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetStickyBombPrefab(this IEntity obj, out SceneEntity value) => obj.TryGetValue(StickyBombPrefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddStickyBombPrefab(this IEntity obj, SceneEntity value) => obj.AddValue(StickyBombPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasStickyBombPrefab(this IEntity obj) => obj.HasValue(StickyBombPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelStickyBombPrefab(this IEntity obj) => obj.DelValue(StickyBombPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStickyBombPrefab(this IEntity obj, SceneEntity value) => obj.SetValue(StickyBombPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetAbilityUseNumber(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(AbilityUseNumber);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAbilityUseNumber(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(AbilityUseNumber, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAbilityUseNumber(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(AbilityUseNumber, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAbilityUseNumber(this IEntity obj) => obj.HasValue(AbilityUseNumber);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAbilityUseNumber(this IEntity obj) => obj.DelValue(AbilityUseNumber);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAbilityUseNumber(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(AbilityUseNumber, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<IEntityAspect[]> GetActiveAbilityAspects(this IEntity obj) => obj.GetValue<ReactiveVariable<IEntityAspect[]>>(ActiveAbilityAspects);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetActiveAbilityAspects(this IEntity obj, out ReactiveVariable<IEntityAspect[]> value) => obj.TryGetValue(ActiveAbilityAspects, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddActiveAbilityAspects(this IEntity obj, ReactiveVariable<IEntityAspect[]> value) => obj.AddValue(ActiveAbilityAspects, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasActiveAbilityAspects(this IEntity obj) => obj.HasValue(ActiveAbilityAspects);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelActiveAbilityAspects(this IEntity obj) => obj.DelValue(ActiveAbilityAspects);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetActiveAbilityAspects(this IEntity obj, ReactiveVariable<IEntityAspect[]> value) => obj.SetValue(ActiveAbilityAspects, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<IEntityAspect> GetApplyAbilityAspectRequest(this IEntity obj) => obj.GetValue<BaseEvent<IEntityAspect>>(ApplyAbilityAspectRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetApplyAbilityAspectRequest(this IEntity obj, out BaseEvent<IEntityAspect> value) => obj.TryGetValue(ApplyAbilityAspectRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddApplyAbilityAspectRequest(this IEntity obj, BaseEvent<IEntityAspect> value) => obj.AddValue(ApplyAbilityAspectRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasApplyAbilityAspectRequest(this IEntity obj) => obj.HasValue(ApplyAbilityAspectRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelApplyAbilityAspectRequest(this IEntity obj) => obj.DelValue(ApplyAbilityAspectRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetApplyAbilityAspectRequest(this IEntity obj, BaseEvent<IEntityAspect> value) => obj.SetValue(ApplyAbilityAspectRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<AbilityCardConfig> GetAbilityCardPickupEvent(this IEntity obj) => obj.GetValue<BaseEvent<AbilityCardConfig>>(AbilityCardPickupEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAbilityCardPickupEvent(this IEntity obj, out BaseEvent<AbilityCardConfig> value) => obj.TryGetValue(AbilityCardPickupEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAbilityCardPickupEvent(this IEntity obj, BaseEvent<AbilityCardConfig> value) => obj.AddValue(AbilityCardPickupEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAbilityCardPickupEvent(this IEntity obj) => obj.HasValue(AbilityCardPickupEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAbilityCardPickupEvent(this IEntity obj) => obj.DelValue(AbilityCardPickupEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAbilityCardPickupEvent(this IEntity obj, BaseEvent<AbilityCardConfig> value) => obj.SetValue(AbilityCardPickupEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<AbilityCardConfig> GetAbilityCardConfig(this IEntity obj) => obj.GetValue<ReactiveVariable<AbilityCardConfig>>(AbilityCardConfig);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAbilityCardConfig(this IEntity obj, out ReactiveVariable<AbilityCardConfig> value) => obj.TryGetValue(AbilityCardConfig, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAbilityCardConfig(this IEntity obj, ReactiveVariable<AbilityCardConfig> value) => obj.AddValue(AbilityCardConfig, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAbilityCardConfig(this IEntity obj) => obj.HasValue(AbilityCardConfig);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAbilityCardConfig(this IEntity obj) => obj.DelValue(AbilityCardConfig);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAbilityCardConfig(this IEntity obj, ReactiveVariable<AbilityCardConfig> value) => obj.SetValue(AbilityCardConfig, value);
    }
}
