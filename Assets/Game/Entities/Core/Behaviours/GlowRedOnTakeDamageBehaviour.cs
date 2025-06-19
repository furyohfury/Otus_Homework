using System;
using System.Threading;
using Atomic.Elements;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class GlowRedOnTakeDamageBehaviour : IEntityInit, IEntityDispose
	{
		[SerializeField]
		private Color _glowColor = Color.red;
		[SerializeField]
		private float _duration = 0.2f;
		private SpriteRenderer[] _spriteRenderers;
		private ReactiveVariable<int> _health;

		private CancellationTokenSource _cts = new();

		public void Init(IEntity entity)
		{
			_spriteRenderers = entity.GetSpriteRenderers();
			_health = entity.GetHealth();
			_health.Subscribe(OnTakeDamage);
		}

		private async void OnTakeDamage(int _)
		{
			var initialColors = new Color[_spriteRenderers.Length];
			for (var i = 0; i < _spriteRenderers.Length; i++)
			{
				initialColors[i] = _spriteRenderers[i].color;
				_spriteRenderers[i].color = _glowColor;
			}

			try
			{
				await UniTask.Delay(TimeSpan.FromSeconds(_duration), cancellationToken: _cts.Token);
			}
			catch
			{
				return;
			}

			for (var i = 0; i < _spriteRenderers.Length; i++)
			{
				_spriteRenderers[i].color = initialColors[i];
			}
		}

		public void Dispose(IEntity entity)
		{
			_health.Unsubscribe(OnTakeDamage);
			_cts.Cancel();
		}
	}
}