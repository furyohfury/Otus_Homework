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
    public static class CommonAPI
    {
        ///Keys
        public const int AudioSource = 57; // AudioSource
        public const int SceneEntity = 62; // SceneEntity
        public const int AnimatorEventReceiver = 67; // AnimatorEventReceiver
        public const int Id = 71; // string


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioSource GetAudioSource(this IEntity obj) => obj.GetValue<AudioSource>(AudioSource);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAudioSource(this IEntity obj, out AudioSource value) => obj.TryGetValue(AudioSource, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAudioSource(this IEntity obj, AudioSource value) => obj.AddValue(AudioSource, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAudioSource(this IEntity obj) => obj.HasValue(AudioSource);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAudioSource(this IEntity obj) => obj.DelValue(AudioSource);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAudioSource(this IEntity obj, AudioSource value) => obj.SetValue(AudioSource, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SceneEntity GetSceneEntity(this IEntity obj) => obj.GetValue<SceneEntity>(SceneEntity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSceneEntity(this IEntity obj, out SceneEntity value) => obj.TryGetValue(SceneEntity, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSceneEntity(this IEntity obj, SceneEntity value) => obj.AddValue(SceneEntity, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSceneEntity(this IEntity obj) => obj.HasValue(SceneEntity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSceneEntity(this IEntity obj) => obj.DelValue(SceneEntity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSceneEntity(this IEntity obj, SceneEntity value) => obj.SetValue(SceneEntity, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnimatorEventReceiver GetAnimatorEventReceiver(this IEntity obj) => obj.GetValue<AnimatorEventReceiver>(AnimatorEventReceiver);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimatorEventReceiver(this IEntity obj, out AnimatorEventReceiver value) => obj.TryGetValue(AnimatorEventReceiver, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimatorEventReceiver(this IEntity obj, AnimatorEventReceiver value) => obj.AddValue(AnimatorEventReceiver, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimatorEventReceiver(this IEntity obj) => obj.HasValue(AnimatorEventReceiver);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimatorEventReceiver(this IEntity obj) => obj.DelValue(AnimatorEventReceiver);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimatorEventReceiver(this IEntity obj, AnimatorEventReceiver value) => obj.SetValue(AnimatorEventReceiver, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetId(this IEntity obj) => obj.GetValue<string>(Id);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetId(this IEntity obj, out string value) => obj.TryGetValue(Id, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddId(this IEntity obj, string value) => obj.AddValue(Id, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasId(this IEntity obj) => obj.HasValue(Id);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelId(this IEntity obj) => obj.DelValue(Id);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetId(this IEntity obj, string value) => obj.SetValue(Id, value);
    }
}
