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
    public static class VisualAPI
    {
        ///Keys
        public const int Animator = 10; // Animator
        public const int VisualTransform = 5; // Transform


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Animator GetAnimator(this IEntity obj) => obj.GetValue<Animator>(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValue(Animator, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetVisualTransform(this IEntity obj) => obj.GetValue<Transform>(VisualTransform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetVisualTransform(this IEntity obj, out Transform value) => obj.TryGetValue(VisualTransform, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddVisualTransform(this IEntity obj, Transform value) => obj.AddValue(VisualTransform, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasVisualTransform(this IEntity obj) => obj.HasValue(VisualTransform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelVisualTransform(this IEntity obj) => obj.DelValue(VisualTransform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetVisualTransform(this IEntity obj, Transform value) => obj.SetValue(VisualTransform, value);
    }
}
