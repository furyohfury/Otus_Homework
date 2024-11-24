using System;
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
	}
}