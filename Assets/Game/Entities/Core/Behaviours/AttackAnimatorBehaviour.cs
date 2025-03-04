using System;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AttackAnimatorBehaviour : IEntityInit, IEntityDispose
	{
		private Animator _animator;
		private int _attackHash;
		private IEvent _attackEvent;
		private BaseEvent _weaponAttackEvent;

		private const string ATTACK_ANIMATOR_PARAM = "Attack";

		public void Init(IEntity entity)
		{
			if (entity.TryGetWeapon(out var weapon)
			    && weapon.Value.TryGetAttackEvent(out var attackEvent))
			{
				_weaponAttackEvent = attackEvent;
				_weaponAttackEvent.Subscribe(OnAttackEvent);
			}
			else
			{
				_attackEvent = entity.GetAttackEvent();
			}

			entity.OnValueDeleted += OnWeaponUnequipped;
			entity.OnValueAdded += OnChangeEquipped;

			_animator = entity.GetAnimator();
			HandleDifferentParametersCase();
		}

		private void OnChangeEquipped(IEntity entity, int id, object value)
		{
			if (id != CombatAPI.Weapon)
			{
				return;
			}

			var weapon = (ReactiveVariable<SceneEntity>)value;
			_weaponAttackEvent = weapon.Value.GetAttackEvent();
			_weaponAttackEvent.Subscribe(OnAttackEvent);
		}

		private void OnWeaponUnequipped(IEntity entity, int id, object value)
		{
			if (id != CombatAPI.Weapon)
			{
				return;
			}

			var weapon = (ReactiveVariable<SceneEntity>)value;
			_weaponAttackEvent = weapon.Value.GetAttackEvent();
			_weaponAttackEvent.Unsubscribe(OnAttackEvent);
		}

		private void HandleDifferentParametersCase()
		{
			var parameters = _animator.parameters;
			var differentCaseParameter = parameters.SingleOrDefault(
				param => param.name.Equals(ATTACK_ANIMATOR_PARAM, StringComparison.OrdinalIgnoreCase));
			var attackAnimatorParam = differentCaseParameter == default
				? ATTACK_ANIMATOR_PARAM
				: differentCaseParameter.name;
			_attackHash = Animator.StringToHash(attackAnimatorParam);
		}

		private void OnAttackEvent()
		{
			_animator.SetTrigger(_attackHash);
		}

		public void Dispose(IEntity entity)
		{
			_weaponAttackEvent?.Unsubscribe(OnAttackEvent);
		}
	}
}