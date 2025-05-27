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
		InputControls.IGameplayActions, 
		InputControls.IUIActions // TODO in separate reader
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

		public static Vector2 RightStickDirection
		{
			get
			{
				if (Gamepad.current == null)
				{
					return Vector2.zero;
				}
				
				var val = Gamepad.current.rightStick.ReadValue();
				return val.normalized;
			}
		}

		public event Action<Vector2> OnMove;
		public event Action OnJumped;
		public event Action OnAttacked;
		public event Action OnAbilityUsed;
		public event Action OnPaused;

		private readonly InputControls _inputControls;
		private bool _attackPressed;

		[Inject]
		public InputReader(InputControls inputControls)
		{
			_inputControls = inputControls;
		}

		public void Initialize()
		{
			_inputControls.Gameplay.SetCallbacks(this);
			_inputControls.UI.SetCallbacks(this);
			EnableMaps();
		}

		private void EnableMaps()
		{
			_inputControls.Gameplay.Enable();
			_inputControls.UI.Enable();
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

		void InputControls.IUIActions.OnPause(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
			{
				OnPaused?.Invoke();
			}
		}

		public void Dispose()
		{
			_inputControls.Gameplay.Disable();
			_inputControls.UI.Disable();
		}
	}
}