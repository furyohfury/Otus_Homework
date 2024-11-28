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

		[Button]
		public void GetAngle()
		{
			var angle = Vector3.Angle(_target.position - _weapon.position, _weapon.right);
			Debug.Log(angle);
		}
		
		[Button]
		public void GetSignedAngle()
		{
			var angle = Vector3.SignedAngle(_target.position - _weapon.position, _weapon.right, Vector3.back);
			Debug.Log(angle);
		}


		[SerializeField]
		private Transform _weapon;
		
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawRay(_weapon.position, _weapon.right);
			Gizmos.color = Color.red;
			Gizmos.DrawRay(_weapon.position, _target.position - _weapon.position);
		}
	}
}