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
    public static class InteractionAPI
    {
        ///Keys
        public const int TriggerReceiver = 23; // TriggerReceiver
        public const int TriggerEnterEvent = 20; // BaseEvent<Collider2D>
        public const int TriggerExitEvent = 24; // BaseEvent<Collider2D>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TriggerReceiver GetTriggerReceiver(this IEntity obj) => obj.GetValue<TriggerReceiver>(TriggerReceiver);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTriggerReceiver(this IEntity obj, out TriggerReceiver value) => obj.TryGetValue(TriggerReceiver, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTriggerReceiver(this IEntity obj, TriggerReceiver value) => obj.AddValue(TriggerReceiver, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTriggerReceiver(this IEntity obj) => obj.HasValue(TriggerReceiver);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTriggerReceiver(this IEntity obj) => obj.DelValue(TriggerReceiver);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTriggerReceiver(this IEntity obj, TriggerReceiver value) => obj.SetValue(TriggerReceiver, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<Collider2D> GetTriggerEnterEvent(this IEntity obj) => obj.GetValue<BaseEvent<Collider2D>>(TriggerEnterEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTriggerEnterEvent(this IEntity obj, out BaseEvent<Collider2D> value) => obj.TryGetValue(TriggerEnterEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTriggerEnterEvent(this IEntity obj, BaseEvent<Collider2D> value) => obj.AddValue(TriggerEnterEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTriggerEnterEvent(this IEntity obj) => obj.HasValue(TriggerEnterEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTriggerEnterEvent(this IEntity obj) => obj.DelValue(TriggerEnterEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTriggerEnterEvent(this IEntity obj, BaseEvent<Collider2D> value) => obj.SetValue(TriggerEnterEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<Collider2D> GetTriggerExitEvent(this IEntity obj) => obj.GetValue<BaseEvent<Collider2D>>(TriggerExitEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTriggerExitEvent(this IEntity obj, out BaseEvent<Collider2D> value) => obj.TryGetValue(TriggerExitEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTriggerExitEvent(this IEntity obj, BaseEvent<Collider2D> value) => obj.AddValue(TriggerExitEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTriggerExitEvent(this IEntity obj) => obj.HasValue(TriggerExitEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTriggerExitEvent(this IEntity obj) => obj.DelValue(TriggerExitEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTriggerExitEvent(this IEntity obj, BaseEvent<Collider2D> value) => obj.SetValue(TriggerExitEvent, value);
    }
}
