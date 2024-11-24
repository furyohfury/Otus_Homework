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
    public static class LifeAPI
    {
        ///Keys
        public const int Health = 18; // ReactiveVariable<int>
        public const int IsDead = 19; // ReactiveVariable<bool>


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
        public static ReactiveVariable<bool> GetIsDead(this IEntity obj) => obj.GetValue<ReactiveVariable<bool>>(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsDead(this IEntity obj, out ReactiveVariable<bool> value) => obj.TryGetValue(IsDead, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.AddValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsDead(this IEntity obj) => obj.HasValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsDead(this IEntity obj) => obj.DelValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.SetValue(IsDead, value);
    }
}
