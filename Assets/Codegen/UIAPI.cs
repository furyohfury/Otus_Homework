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
    }
}
