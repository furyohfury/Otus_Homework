using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class SpriteRenderersInstaller : IEntityInstaller
	{
		[SerializeField]
		private SpriteRenderer[] _spriteRenderers;
		
		public void Install(IEntity entity)
		{
			entity.AddSpriteRenderers(_spriteRenderers);
		}
	}
}