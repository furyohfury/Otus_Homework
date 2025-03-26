using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using Newtonsoft.Json;
using SaveLoad;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Zenject;

namespace GameDebug
{
	public class DebugHelper : MonoBehaviour
	{
		[SerializeField] [TabGroup("Entities")]
		private Transform _transform;
		[SerializeField] [TabGroup("Entities")]
		private LayerMask _groundLayer;
		private Vector3 defaultRot;
		[SerializeField] [TabGroup("Entities")]
		private Transform _target;
		[SerializeField] [TabGroup("Entities")]
		private SceneEntity _character;
		[SerializeField] [TabGroup("Entities")]
		private Transform _weapon;
		[SerializeField] [TabGroup("Entities")]
		private Rigidbody2D _rigidbody2D;
		[SerializeField]
		private bool _drawGizmos;

		[SerializeField] [TabGroup("Entities")]
		private Timer _timer;
		private LevelManager _levelManager;
		private GameStateManager _gameStateManager;
		private SaveLoadManager _saveLoadManager;
		private DiContainer _diContainer;
		[SerializeField] [TabGroup("Entities")]
		private SceneEntity _entity;

		[SerializeField] [TabGroup("Adressables")]
		private Image _adressableTestImage;
		[SerializeField] [TabGroup("Adressables")]
		private AssetReference _assetReference;

		[TabGroup("Adressables")] [ShowInInspector]
		public static IReadOnlyDictionary<string, int> AssetReferenceCount => AdressablesLoadManager.AssetReferenceCount;

		[TabGroup("SaveLoad|Lifecycle")] [ShowInInspector]
		public GameState State => _gameStateManager.State;

		// [TabGroup("Level")] [ShowInInspector]
		// private List<TimeSpan> _leaderboard => _lb.Times.ToList();

		private Leaderboard _lb;

		[Inject]
		private void Construct(GameStateManager gameStateManager, SaveLoadManager saveLoadManager, DiContainer diContainer, LevelManager levelManager,
			Leaderboard lb)
		{
			_gameStateManager = gameStateManager;
			_saveLoadManager = saveLoadManager;
			_diContainer = diContainer;
			_levelManager = levelManager;
			_lb = lb;
		}

		private void Start()
		{
			_gameStateManager.ChangeState(GameState.Start);
		}

		[Button] [TabGroup("Entities")]
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

		[Button] [TabGroup("Entities")]
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

		[Button] [TabGroup("Entities")]
		public void AddTarget()
		{
			var target = new ReactiveVariable<Transform>(_target);
			// _character.AddTarget(new BaseFunction<Vector2>(() => _target.position));
		}

		[Button] [TabGroup("Entities")]
		public void GetAngle()
		{
			var angle = Vector3.Angle(_target.position - _weapon.position, _weapon.right);
			Debug.Log(angle);
		}

		[Button] [TabGroup("Entities")]
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


		[Button] [TabGroup("Entities")]
		private void ApplyForce(Vector2 force, ForceMode2D mode)
		{
			_rigidbody2D.AddForce(force, mode);
		}

		[Button] [TabGroup("Entities")]
		private void ApplyVelocity(Vector2 velocity)
		{
			_rigidbody2D.linearVelocity += velocity;
		}

		[Button] [TabGroup("Entities")]
		private void AddDamageVariable(int value)
		{
			_character.AddDamage(new ReactiveVariable<int>(value));
		}

		[Button] [TabGroup("Entities")]
		private void AddDamageValue(int value)
		{
			_character.AddDamage(value);
		}

		// [Button]
		// private async UniTask SwitchScene()
		// {
		// 	DontDestroyOnLoad(this.gameObject);
		// 	SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
		// 	var task = UniTask.Delay(TimeSpan.FromSeconds(5));
		// 	await UniTask.WhenAll(SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive).ToUniTask(), task);
		// 	SceneManager.UnloadSceneAsync("LoadingScreen");
		// }

		[Button] [TabGroup("SaveLoad|Lifecycle")]
		private void ChangeState(GameState state)
		{
			_gameStateManager.ChangeState(state);
		}

		[Button] [TabGroup("SaveLoad|Lifecycle")]
		private void SaveState()
		{
			_saveLoadManager.Save();
		}

		[Button] [TabGroup("SaveLoad|Lifecycle")]
		private void LoadState()
		{
			_saveLoadManager.Load();
		}

		[Button]
		private void TypeDataPath()
		{
			Debug.Log(Application.persistentDataPath);
		}

		private string s = string.Empty;

		[Button] [TabGroup("Entities")]
		private void ReactiveVarSerialize()
		{
			_entity.AddHealth(new ReactiveVariable<int>(10));
			s = JsonConvert.SerializeObject(_entity.Values);
			foreach (KeyValuePair<int, object> keyValuePair in _entity.Values)
			{
				var type = keyValuePair.Value.GetType();
				Debug.Log($"Type = {type}");
			}

			Debug.Log($"Serialized string = {s}");
		}

		[Button] [TabGroup("Entities")]
		private void ReactiveVarDeserialize()
		{
			var r = JsonConvert.DeserializeObject<object>(s);
			_entity.SetValue(18, 10);
		}

		[Button] [TabGroup("SaveLoad|Lifecycle")]
		private void PrintTypes()
		{
			var r = JsonConvert.DeserializeObject<Dictionary<int, object>>(s);
			foreach (KeyValuePair<int, object> pair in r)
			{
				Debug.Log($"{pair.Value.GetType()}");
			}
		}

		[Button] [TabGroup("Adressables")]
		private async void LoadAsset()
		{
			AsyncOperationHandle<Sprite> handle = _assetReference.LoadAssetAsync<Sprite>();
			var image = await handle.Task;
			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				_adressableTestImage.sprite = image;
			}
		}

		[Button] [TabGroup("Adressables")]
		private void ReleaseAsset()
		{
			_assetReference.ReleaseAsset();
		}

		[Button] [TabGroup("Adressables")]
		private async void LoadAssetWithManager()
		{
			Sprite image = await AdressablesLoadManager.LoadAsset<Sprite>(_assetReference);
			_adressableTestImage.sprite = image;
		}

		[Button] [TabGroup("Adressables")]
		private void ReleaseAssetWithManager()
		{
			AdressablesLoadManager.ReleaseAsset(_assetReference);
		}

		[Button] [TabGroup("Level")]
		private void StartLevel()
		{
			_levelManager.StartLevel();
		}

		[Button] [TabGroup("Level")]
		private void FinishLevel()
		{
			_levelManager.FinishLevel();
		}

		[Button] [TabGroup("Level")]
		private void RestartLevel()
		{
			_levelManager.ResetLevel();
		}
	}
}