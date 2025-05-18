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
    public static class UIAPI
    {
        ///Keys
        public const int HealthBar = 73; // HealthBar
        public const int EntityWorldUI = 74; // GameObject


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HealthBar GetHealthBar(this IEntity obj) => obj.GetValue<HealthBar>(HealthBar);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHealthBar(this IEntity obj, out HealthBar value) => obj.TryGetValue(HealthBar, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHealthBar(this IEntity obj, HealthBar value) => obj.AddValue(HealthBar, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHealthBar(this IEntity obj) => obj.HasValue(HealthBar);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHealthBar(this IEntity obj) => obj.DelValue(HealthBar);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHealthBar(this IEntity obj, HealthBar value) => obj.SetValue(HealthBar, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameObject GetEntityWorldUI(this IEntity obj) => obj.GetValue<GameObject>(EntityWorldUI);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetEntityWorldUI(this IEntity obj, out GameObject value) => obj.TryGetValue(EntityWorldUI, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddEntityWorldUI(this IEntity obj, GameObject value) => obj.AddValue(EntityWorldUI, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEntityWorldUI(this IEntity obj) => obj.HasValue(EntityWorldUI);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelEntityWorldUI(this IEntity obj) => obj.DelValue(EntityWorldUI);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEntityWorldUI(this IEntity obj, GameObject value) => obj.SetValue(EntityWorldUI, value);
    }
}
