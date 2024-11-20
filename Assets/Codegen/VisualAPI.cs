/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class VisualAPI
    {
        ///Keys
        public const int Animator = 10; // Animator
        public const int VisualTransfoirm = 5; // Transform


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
        public static Transform GetVisualTransfoirm(this IEntity obj) => obj.GetValue<Transform>(VisualTransfoirm);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetVisualTransfoirm(this IEntity obj, out Transform value) => obj.TryGetValue(VisualTransfoirm, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddVisualTransfoirm(this IEntity obj, Transform value) => obj.AddValue(VisualTransfoirm, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasVisualTransfoirm(this IEntity obj) => obj.HasValue(VisualTransfoirm);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelVisualTransfoirm(this IEntity obj) => obj.DelValue(VisualTransfoirm);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetVisualTransfoirm(this IEntity obj, Transform value) => obj.SetValue(VisualTransfoirm, value);
    }
}
