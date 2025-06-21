using System;
using Atomic.Entities;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class FloatOnPlaceBehaviour : IEntityInit, IEntityEnable, IEntityDisable, IEntityDispose
	{
		[SerializeField]
		private float _floatingDistance = 1f;
		[SerializeField]
		private float _duration;
		private Transform _visualTransform;
		private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

		public void Init(IEntity entity)
		{
			_visualTransform = entity.GetVisualTransform();
			float centerY = _visualTransform.position.y;
			float halfDistance = _floatingDistance / 2f;

			_tween = _visualTransform
			         .DOMoveY(centerY + halfDistance, _duration)
			         .SetEase(Ease.InOutSine)
			         .SetLoops(-1, LoopType.Yoyo)
			         .From(centerY - halfDistance);
		}

		public void Enable(IEntity entity)
		{
			_tween.Play();
		}

		public void Disable(IEntity entity)
		{
			_tween.Pause();
		}

		public void Dispose(IEntity entity)
		{
			Debug.Log("Tween killed");
			_tween?.Kill();
		}
	}
}