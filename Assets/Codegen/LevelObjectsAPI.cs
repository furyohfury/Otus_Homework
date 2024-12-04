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
    public static class LevelObjectsAPI
    {
        ///Keys
        public const int DestroyEvent = 39; // BaseEvent


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetDestroyEvent(this IEntity obj) => obj.GetValue<BaseEvent>(DestroyEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDestroyEvent(this IEntity obj, out BaseEvent value) => obj.TryGetValue(DestroyEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDestroyEvent(this IEntity obj, BaseEvent value) => obj.AddValue(DestroyEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDestroyEvent(this IEntity obj) => obj.HasValue(DestroyEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDestroyEvent(this IEntity obj) => obj.DelValue(DestroyEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDestroyEvent(this IEntity obj, BaseEvent value) => obj.SetValue(DestroyEvent, value);
    }
}
