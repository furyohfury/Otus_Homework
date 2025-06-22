using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class SwitchPhysicsMaterialInAirBehaviour : IEntityInit, IEntityFixedUpdate
	{
		[SerializeField]
		private PhysicsMaterial2D _inAirMaterial;
		private IFunction<bool> _isGrounded;
		private Rigidbody2D _rigidbody2D;
		private PhysicsMaterial2D _initialMaterial;

		private bool _switched;

		public void Init(IEntity entity)
		{
			_isGrounded = entity.GetIsGrounded();
			_rigidbody2D = entity.GetRigidbody2D();
			_initialMaterial = _rigidbody2D.sharedMaterial;
		}

		public void OnFixedUpdate(IEntity entity, float deltaTime)
		{
			bool isGrounded = _isGrounded.Invoke();
			if (isGrounded && _switched)
			{
				_rigidbody2D.sharedMaterial = _initialMaterial;
				_switched = false;
			}
			else if (!isGrounded && !_switched)
			{
				_rigidbody2D.sharedMaterial = _inAirMaterial;
				_switched = true;
			}
		}
	}
}