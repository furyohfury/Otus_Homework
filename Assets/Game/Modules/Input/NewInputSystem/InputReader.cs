using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
	public sealed class InputReader :
		IInitializable,
		ITickable,
		IDisposable,
		InputControls.IGameplayActions
	{
		public static Vector2 MousePosition
		{
			get
			{
				var mouse = Mouse.current;
				return mouse != null
					? mouse.position.ReadValue()
					: default;
			}
		}

		public Vector2 RightStickDirection => _rightStickDirection;

		public event Action<Vector2> OnMove;
		public event Action OnJumped;
		public event Action OnAttacked;
		public event Action OnAbilityUsed;
		public event Action<Vector2> OnAimed;
		public event Action OnPaused;

		private readonly InputControls _inputControls;
		private Vector2 _rightStickDirection;
		private bool _attackPressed;

		[Inject]
		public InputReader(InputControls inputControls)
		{
			_inputControls = inputControls;
		}

		public void Initialize()
		{
			_inputControls.Gameplay.SetCallbacks(this);
		}

		public void Tick()
		{
			CheckAttackInput();
		}

		private void CheckAttackInput()
		{
			var isPressed = _inputControls.Gameplay.Attack.IsPressed();
			if (isPressed)
			{
				OnAttacked?.Invoke();
			}
		}

		void InputControls.IGameplayActions.OnMovement(InputAction.CallbackContext context)
		{
			var movement = context.ReadValue<Vector2>();
			OnMove?.Invoke(movement);
		}

		void InputControls.IGameplayActions.OnJump(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
			{
				OnJumped?.Invoke();
			}
		}

		void InputControls.IGameplayActions.OnAttack(InputAction.CallbackContext context)
		{
		}

		void InputControls.IGameplayActions.OnAbility(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
			{
				OnAbilityUsed?.Invoke();
			}
		}

		void InputControls.IGameplayActions.OnPause(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
			{
				OnPaused?.Invoke();
			}
		}

		void InputControls.IGameplayActions.OnAim(InputAction.CallbackContext context)
		{
			var aim = context.ReadValue<Vector2>();
			OnAimed?.Invoke(aim);
			_rightStickDirection = aim;
		}

		public void Dispose()
		{
			_inputControls.Gameplay.Disable();
			_inputControls.UI.Disable();
		}
	}
}