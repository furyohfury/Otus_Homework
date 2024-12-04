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
    public static class MovementAPI
    {
        ///Keys
        public const int MoveSpeed = 1; // ReactiveVariable<float>
        public const int MoveDirection = 2; // ReactiveVariable<Vector2>
        public const int CanMove = 3; // AndExpression
        public const int CanJump = 4; // AndExpression
        public const int IsGrounded = 6; // BaseFunction<bool>
        public const int JumpForce = 8; // ReactiveVariable<float>
        public const int JumpRequest = 9; // BaseEvent
        public const int JumpEvent = 12; // BaseEvent
        public const int Target = 32; // IFunction<Vector2>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetMoveSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(MoveSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Vector2> GetMoveDirection(this IEntity obj) => obj.GetValue<ReactiveVariable<Vector2>>(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveDirection(this IEntity obj, out ReactiveVariable<Vector2> value) => obj.TryGetValue(MoveDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveDirection(this IEntity obj, ReactiveVariable<Vector2> value) => obj.AddValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveDirection(this IEntity obj, ReactiveVariable<Vector2> value) => obj.SetValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanMove(this IEntity obj) => obj.GetValue<AndExpression>(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanMove(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanMove, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanMove(this IEntity obj, AndExpression value) => obj.AddValue(CanMove, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanMove(this IEntity obj) => obj.HasValue(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanMove(this IEntity obj) => obj.DelValue(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanMove(this IEntity obj, AndExpression value) => obj.SetValue(CanMove, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanJump(this IEntity obj) => obj.GetValue<AndExpression>(CanJump);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanJump(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanJump, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanJump(this IEntity obj, AndExpression value) => obj.AddValue(CanJump, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanJump(this IEntity obj) => obj.HasValue(CanJump);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanJump(this IEntity obj) => obj.DelValue(CanJump);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanJump(this IEntity obj, AndExpression value) => obj.SetValue(CanJump, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseFunction<bool> GetIsGrounded(this IEntity obj) => obj.GetValue<BaseFunction<bool>>(IsGrounded);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsGrounded(this IEntity obj, out BaseFunction<bool> value) => obj.TryGetValue(IsGrounded, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsGrounded(this IEntity obj, BaseFunction<bool> value) => obj.AddValue(IsGrounded, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsGrounded(this IEntity obj) => obj.HasValue(IsGrounded);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsGrounded(this IEntity obj) => obj.DelValue(IsGrounded);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsGrounded(this IEntity obj, BaseFunction<bool> value) => obj.SetValue(IsGrounded, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetJumpForce(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(JumpForce);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetJumpForce(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(JumpForce, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddJumpForce(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(JumpForce, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasJumpForce(this IEntity obj) => obj.HasValue(JumpForce);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelJumpForce(this IEntity obj) => obj.DelValue(JumpForce);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetJumpForce(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(JumpForce, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetJumpRequest(this IEntity obj) => obj.GetValue<BaseEvent>(JumpRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetJumpRequest(this IEntity obj, out BaseEvent value) => obj.TryGetValue(JumpRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddJumpRequest(this IEntity obj, BaseEvent value) => obj.AddValue(JumpRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasJumpRequest(this IEntity obj) => obj.HasValue(JumpRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelJumpRequest(this IEntity obj) => obj.DelValue(JumpRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetJumpRequest(this IEntity obj, BaseEvent value) => obj.SetValue(JumpRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetJumpEvent(this IEntity obj) => obj.GetValue<BaseEvent>(JumpEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetJumpEvent(this IEntity obj, out BaseEvent value) => obj.TryGetValue(JumpEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddJumpEvent(this IEntity obj, BaseEvent value) => obj.AddValue(JumpEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasJumpEvent(this IEntity obj) => obj.HasValue(JumpEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelJumpEvent(this IEntity obj) => obj.DelValue(JumpEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetJumpEvent(this IEntity obj, BaseEvent value) => obj.SetValue(JumpEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IFunction<Vector2> GetTarget(this IEntity obj) => obj.GetValue<IFunction<Vector2>>(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTarget(this IEntity obj, out IFunction<Vector2> value) => obj.TryGetValue(Target, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTarget(this IEntity obj, IFunction<Vector2> value) => obj.AddValue(Target, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTarget(this IEntity obj) => obj.HasValue(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTarget(this IEntity obj) => obj.DelValue(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTarget(this IEntity obj, IFunction<Vector2> value) => obj.SetValue(Target, value);
    }
}
