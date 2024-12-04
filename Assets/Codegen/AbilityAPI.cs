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
        public const int ActiveAspect = 41; // IEntityAspect


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
        public static IEntityAspect GetActiveAspect(this IEntity obj) => obj.GetValue<IEntityAspect>(ActiveAspect);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetActiveAspect(this IEntity obj, out IEntityAspect value) => obj.TryGetValue(ActiveAspect, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddActiveAspect(this IEntity obj, IEntityAspect value) => obj.AddValue(ActiveAspect, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasActiveAspect(this IEntity obj) => obj.HasValue(ActiveAspect);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelActiveAspect(this IEntity obj) => obj.DelValue(ActiveAspect);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetActiveAspect(this IEntity obj, IEntityAspect value) => obj.SetValue(ActiveAspect, value);
    }
}
