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
    public static class AbilityAPI
    {
        ///Keys
        public const int AbilityRequest = 36; // BaseEvent
        public const int AbilityEvent = 37; // BaseEvent
        public const int DashForce = 38; // ReactiveVariable<float>


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
    }
}
