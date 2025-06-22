using System;
using System.Threading;
using Atomic.Elements;
using Atomic.Entities;
using DG.Tweening;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class GlowRedOnTakeDamageBehaviour : IEntityInit, IEntityEnable, IEntityDisable, IEntityDispose
	{
		[SerializeField]
		private Color _glowColor = Color.red;
		[SerializeField]
		private float _duration = 0.2f;
		private SpriteRenderer[] _spriteRenderers;
		private ReactiveVariable<int> _health;

		private CancellationTokenSource _cts = new();
		private Tween _restoreTween;

		public void Init(IEntity entity)
		{
			_spriteRenderers = entity.GetSpriteRenderers();
			_health = entity.GetHealth();
			_health.Subscribe(OnTakeDamage);
		}

		private void OnTakeDamage(int _)
		{
			if (_restoreTween != null)
			{
				return;
			}
			
			var initialColors = new Color[_spriteRenderers.Length];
			for (var i = 0; i < _spriteRenderers.Length; i++)
			{
				initialColors[i] = _spriteRenderers[i].color;
				_spriteRenderers[i].color = _glowColor;
			}

			_restoreTween = DOVirtual.DelayedCall(_duration, () =>
			{
				RestoreColors(initialColors);
				_restoreTween = null;
			});
		}

		private void RestoreColors(Color[] initialColors)
		{
			for (var i = 0; i < _spriteRenderers.Length; i++)
			{
				_spriteRenderers[i].color = initialColors[i];
			}
		}

		public void Enable(IEntity entity)
		{
			_restoreTween?.Play();
		}

		public void Disable(IEntity entity)
		{
			_restoreTween?.Pause();
		}

		public void Dispose(IEntity entity)
		{
			_health.Unsubscribe(OnTakeDamage);
			_cts.Cancel();
		}
	}
}