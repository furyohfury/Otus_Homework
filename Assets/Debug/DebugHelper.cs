using System;
using System.Threading.Tasks;
using Atomic.Elements;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace a
{
	public class DebugHelper : MonoBehaviour
	{
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private LayerMask _groundLayer;
		private Vector3 defaultRot;
		[SerializeField]
		private Transform _target;
		[SerializeField]
		private SceneEntity _character;
		[SerializeField]
		private Transform _weapon;
		[SerializeField]
		private Rigidbody2D _rigidbody2D;
		[SerializeField]
		private bool _drawGizmos;

		[SerializeField]
		private Timer _timer;
		private LevelManager _levelManager;


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
		public void AddTarget()
		{
			var target = new ReactiveVariable<Transform>(_target);
			_character.AddTarget(new BaseFunction<Vector2>(() => _target.position));
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


		private void OnDrawGizmos()
		{
			if (!_drawGizmos)
			{
				return;
			}

			Gizmos.color = Color.blue;
			Gizmos.DrawRay(_weapon.position, _weapon.right);
			Gizmos.color = Color.red;
			Gizmos.DrawRay(_weapon.position, _target.position - _weapon.position);
		}


		[Button]
		private void ApplyForce(Vector2 force, ForceMode2D mode)
		{
			_rigidbody2D.AddForce(force, mode);
		}

		[Button]
		private void ApplyVelocity(Vector2 velocity)
		{
			_rigidbody2D.velocity += velocity;
		}

		[Button]
		private void AddDamageVariable(int value)
		{
			_character.AddDamage(new ReactiveVariable<int>(value));
		}
		
		[Button]
		private void AddDamageValue(int value)
		{
			_character.AddDamage(value);
		}

		[Button]
		private async UniTask SwitchScene()
		{
			DontDestroyOnLoad(this.gameObject);
			SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
			var task = UniTask.Delay(TimeSpan.FromSeconds(5));
			await UniTask.WhenAll(SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive).ToUniTask(), task);
			SceneManager.UnloadSceneAsync("LoadingScreen");
		}
	}
}