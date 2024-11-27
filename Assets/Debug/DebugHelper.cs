using System;
using Atomic.Elements;
using Atomic.Entities;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace a
{
	public class DebugHelper : MonoBehaviour
	{
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private LayerMask _groundLayer;
		[SerializeField]
		private Transform _sword;
		private Vector3 defaultRot;
		[SerializeField]
		private Transform _target;
		[SerializeField]
		private SceneEntity _entity;
		


		private void Start()
		{
			defaultRot = _sword.rotation.eulerAngles;
		}

		[Button]
		public void CheckOverlapPoint()
		{
			if (Physics2D.OverlapPoint(_transform.position, _groundLayer) != null)
			{
				Debug.Log("hit");
			}
			else
			{
				Debug.Log("no hit");
			}
		}
		
		[Button]
		public void CheckOverlapSphere()
		{
			if (Physics2D.OverlapCircle(_transform.position, 0.1f, _groundLayer) != null)
			{
				Debug.Log("hit");
			}
			else
			{
				Debug.Log("no hit");
			}
		}

		[Button]
		public void Animate(int i)
		{
			if (i == 1)
			{
				_sword.DORotate(defaultRot + new Vector3(0, 0, -90f), 1f);
			}
			else if (i == 2)
			{
				_sword.DORotate(new Vector3(0, 0, -90f), 1f);
			}
		}


		[Button]
		public void AddTarget()
		{
			var target = new ReactiveVariable<Transform>(_target);
			_entity.AddTarget(target);
		}
	}
}