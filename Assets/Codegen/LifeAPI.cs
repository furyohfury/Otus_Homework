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
    public static class LifeAPI
    {
        ///Keys
        public const int Health = 18; // ReactiveVariable<int>
        public const int IsDead = 19; // BaseFunction<bool>
        public const int CanTakeDamage = 26; // AndExpression
        public const int TakeDamageRequest = 27; // BaseEvent<int>
        public const int TakeDamageEvent = 28; // BaseEvent<int>
        public const int DeathEvent = 34; // BaseEvent
        public const int MaxHealth = 49; // ReactiveVariable<int>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetHealth(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(Health);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHealth(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(Health, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHealth(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(Health, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHealth(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(Health, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseFunction<bool> GetIsDead(this IEntity obj) => obj.GetValue<BaseFunction<bool>>(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsDead(this IEntity obj, out BaseFunction<bool> value) => obj.TryGetValue(IsDead, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsDead(this IEntity obj, BaseFunction<bool> value) => obj.AddValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsDead(this IEntity obj) => obj.HasValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsDead(this IEntity obj) => obj.DelValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsDead(this IEntity obj, BaseFunction<bool> value) => obj.SetValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanTakeDamage(this IEntity obj) => obj.GetValue<AndExpression>(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanTakeDamage(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanTakeDamage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanTakeDamage(this IEntity obj, AndExpression value) => obj.AddValue(CanTakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanTakeDamage(this IEntity obj) => obj.HasValue(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanTakeDamage(this IEntity obj) => obj.DelValue(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanTakeDamage(this IEntity obj, AndExpression value) => obj.SetValue(CanTakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetTakeDamageRequest(this IEntity obj) => obj.GetValue<BaseEvent<int>>(TakeDamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamageRequest(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(TakeDamageRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.AddValue(TakeDamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamageRequest(this IEntity obj) => obj.HasValue(TakeDamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamageRequest(this IEntity obj) => obj.DelValue(TakeDamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.SetValue(TakeDamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetTakeDamageEvent(this IEntity obj) => obj.GetValue<BaseEvent<int>>(TakeDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamageEvent(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(TakeDamageEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamageEvent(this IEntity obj, BaseEvent<int> value) => obj.AddValue(TakeDamageEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamageEvent(this IEntity obj) => obj.HasValue(TakeDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamageEvent(this IEntity obj) => obj.DelValue(TakeDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamageEvent(this IEntity obj, BaseEvent<int> value) => obj.SetValue(TakeDamageEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetDeathEvent(this IEntity obj) => obj.GetValue<BaseEvent>(DeathEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDeathEvent(this IEntity obj, out BaseEvent value) => obj.TryGetValue(DeathEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDeathEvent(this IEntity obj, BaseEvent value) => obj.AddValue(DeathEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDeathEvent(this IEntity obj) => obj.HasValue(DeathEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDeathEvent(this IEntity obj) => obj.DelValue(DeathEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDeathEvent(this IEntity obj, BaseEvent value) => obj.SetValue(DeathEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetMaxHealth(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxHealth(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(MaxHealth, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxHealth(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(MaxHealth, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxHealth(this IEntity obj) => obj.HasValue(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxHealth(this IEntity obj) => obj.DelValue(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxHealth(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(MaxHealth, value);
    }
}
