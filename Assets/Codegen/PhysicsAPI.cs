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

namespace Atomic.Entities
{
    public static class PhysicsAPI
    {
        ///Keys
        public const int Rigidbody = 11; // Rigidbody2D
        public const int Collider2D = 21; // Collider2D


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rigidbody2D GetRigidbody(this IEntity obj) => obj.GetValue<Rigidbody2D>(Rigidbody);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRigidbody(this IEntity obj, out Rigidbody2D value) => obj.TryGetValue(Rigidbody, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRigidbody(this IEntity obj, Rigidbody2D value) => obj.AddValue(Rigidbody, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRigidbody(this IEntity obj) => obj.HasValue(Rigidbody);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRigidbody(this IEntity obj) => obj.DelValue(Rigidbody);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRigidbody(this IEntity obj, Rigidbody2D value) => obj.SetValue(Rigidbody, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Collider2D GetCollider2D(this IEntity obj) => obj.GetValue<Collider2D>(Collider2D);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCollider2D(this IEntity obj, out Collider2D value) => obj.TryGetValue(Collider2D, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCollider2D(this IEntity obj, Collider2D value) => obj.AddValue(Collider2D, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCollider2D(this IEntity obj) => obj.HasValue(Collider2D);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCollider2D(this IEntity obj) => obj.DelValue(Collider2D);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCollider2D(this IEntity obj, Collider2D value) => obj.SetValue(Collider2D, value);
    }
}
