using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class DisableSpritesOnDeathRequestBehaviour : IEntityInit, IEntityDispose
	{
		private IEvent _deathRequest;
		private SpriteRenderer[] _spriteRenderers;

		public void Init(IEntity entity)
		{
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeathRequest);
			_spriteRenderers = entity.GetSpriteRenderers();
		}

		private void OnDeathRequest()
		{
			for (int i = 0, count = _spriteRenderers.Length; i < count; i++)
			{
				_spriteRenderers[i].enabled = false;
			}
		}

		public void Dispose(IEntity entity)
		{
			_deathRequest.Unsubscribe(OnDeathRequest);
		}
	}
}