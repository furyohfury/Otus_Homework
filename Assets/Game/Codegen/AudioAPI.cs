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
    public static class AudioAPI
    {
        ///Keys
        public const int FootstepsSounds = 60; // AudioClip[]
        public const int DeathSounds = 61; // AudioClip[]
        public const int TakeDamageSounds = 63; // AudioClip[]
        public const int ShootSFX = 76; // AudioClip[]


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioClip[] GetFootstepsSounds(this IEntity obj) => obj.GetValue<AudioClip[]>(FootstepsSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetFootstepsSounds(this IEntity obj, out AudioClip[] value) => obj.TryGetValue(FootstepsSounds, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddFootstepsSounds(this IEntity obj, AudioClip[] value) => obj.AddValue(FootstepsSounds, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFootstepsSounds(this IEntity obj) => obj.HasValue(FootstepsSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelFootstepsSounds(this IEntity obj) => obj.DelValue(FootstepsSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFootstepsSounds(this IEntity obj, AudioClip[] value) => obj.SetValue(FootstepsSounds, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioClip[] GetDeathSounds(this IEntity obj) => obj.GetValue<AudioClip[]>(DeathSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDeathSounds(this IEntity obj, out AudioClip[] value) => obj.TryGetValue(DeathSounds, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDeathSounds(this IEntity obj, AudioClip[] value) => obj.AddValue(DeathSounds, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDeathSounds(this IEntity obj) => obj.HasValue(DeathSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDeathSounds(this IEntity obj) => obj.DelValue(DeathSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDeathSounds(this IEntity obj, AudioClip[] value) => obj.SetValue(DeathSounds, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioClip[] GetTakeDamageSounds(this IEntity obj) => obj.GetValue<AudioClip[]>(TakeDamageSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamageSounds(this IEntity obj, out AudioClip[] value) => obj.TryGetValue(TakeDamageSounds, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamageSounds(this IEntity obj, AudioClip[] value) => obj.AddValue(TakeDamageSounds, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamageSounds(this IEntity obj) => obj.HasValue(TakeDamageSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamageSounds(this IEntity obj) => obj.DelValue(TakeDamageSounds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamageSounds(this IEntity obj, AudioClip[] value) => obj.SetValue(TakeDamageSounds, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioClip[] GetShootSFX(this IEntity obj) => obj.GetValue<AudioClip[]>(ShootSFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootSFX(this IEntity obj, out AudioClip[] value) => obj.TryGetValue(ShootSFX, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootSFX(this IEntity obj, AudioClip[] value) => obj.AddValue(ShootSFX, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootSFX(this IEntity obj) => obj.HasValue(ShootSFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootSFX(this IEntity obj) => obj.DelValue(ShootSFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootSFX(this IEntity obj, AudioClip[] value) => obj.SetValue(ShootSFX, value);
    }
}
