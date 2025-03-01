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
    public static class CommonAPI
    {
        ///Keys
        public const int AudioSource = 57; // AudioSource
        public const int SceneEntity = 62; // SceneEntity
        public const int AnimatorEventReceiver = 67; // AnimatorEventReceiver
        public const int SpawnWorldEvent = 71; // IEvent<IEntity>
        public const int DestroyWorldEvent = 72; // IEvent<IEntity>


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
        public static IEvent<IEntity> GetSpawnWorldEvent(this IEntity obj) => obj.GetValue<IEvent<IEntity>>(SpawnWorldEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSpawnWorldEvent(this IEntity obj, out IEvent<IEntity> value) => obj.TryGetValue(SpawnWorldEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSpawnWorldEvent(this IEntity obj, IEvent<IEntity> value) => obj.AddValue(SpawnWorldEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSpawnWorldEvent(this IEntity obj) => obj.HasValue(SpawnWorldEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSpawnWorldEvent(this IEntity obj) => obj.DelValue(SpawnWorldEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSpawnWorldEvent(this IEntity obj, IEvent<IEntity> value) => obj.SetValue(SpawnWorldEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEvent<IEntity> GetDestroyWorldEvent(this IEntity obj) => obj.GetValue<IEvent<IEntity>>(DestroyWorldEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDestroyWorldEvent(this IEntity obj, out IEvent<IEntity> value) => obj.TryGetValue(DestroyWorldEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDestroyWorldEvent(this IEntity obj, IEvent<IEntity> value) => obj.AddValue(DestroyWorldEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDestroyWorldEvent(this IEntity obj) => obj.HasValue(DestroyWorldEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDestroyWorldEvent(this IEntity obj) => obj.DelValue(DestroyWorldEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDestroyWorldEvent(this IEntity obj, IEvent<IEntity> value) => obj.SetValue(DestroyWorldEvent, value);
    }
}
