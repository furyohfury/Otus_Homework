using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class IsGroundedInstaller : IEntityInstaller
	{
		[SerializeField]
		private Transform _groundCheckTransform;
		[SerializeField]
		private Rigidbody2D _rigidbody2D;
		[SerializeField]
		private LayerMask _groundLayer;

		public void Install(IEntity entity)
		{
			var distance = ((Vector2)_groundCheckTransform.position - _rigidbody2D.position).magnitude;
			var isGrounded = new BaseFunction<bool>(() =>
			{
				var i = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, distance, _groundLayer);
				return i != default;
			});
			entity.AddIsGrounded(isGrounded);
		}
	}
}