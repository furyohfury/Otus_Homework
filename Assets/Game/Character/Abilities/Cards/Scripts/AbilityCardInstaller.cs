using System.Threading.Tasks;
using Atomic.Elements;
using Atomic.Entities;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game
{
	public sealed class AbilityCardInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private SpriteRenderer _renderer;
		[SerializeField]
		private AssetReference _abilityCardConfigReference;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField]
		private Transform _transform;

		private SceneEntity _entity;

		public override void Install(IEntity entity)
		{
			entity.AddAbilityCardTag();
			_triggerReceiver.OnTriggerEnter += OnTrigger;
			entity.AddVisualTransform(_transform);
			entity.AddSpriteRenderer(_renderer);
			_entity = GetComponent<SceneEntity>();

			if (_abilityCardConfigReference != null)
			{
				InstallConfig(entity, _abilityCardConfigReference);
			}			
		}

		public async Task InstallConfig(IEntity entity, AssetReference configAsset)
		{
			AbilityCardConfig config = await AdressablesLoadManager.LoadAsset<AbilityCardConfig>(_abilityCardConfigReference);
			if (_renderer.sprite == null)
			{
				_renderer.sprite = config.Sprite;
			}
			entity.AddAbilityCardGUID(_abilityCardConfigReference.AssetGUID);
		}

		private void OnTrigger(Collider2D other)
		{
			if (!other.TryGetEntity(out var entity) || !entity.HasCharacterTag())
			{
				return;
			}

			if (entity.TryGetAbilityCardPickupEvent(out BaseEvent<AssetReference> pickupEvent))
			{
				pickupEvent.Invoke(_abilityCardConfigReference);
			}

			SceneEntityCreator.OnDestroyEntityRequest(_entity);
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (_renderer.sprite != null)
			{
				return;
			}
			var assetPath = AssetDatabase.GUIDToAssetPath(_abilityCardConfigReference.AssetGUID);
			if (!string.IsNullOrEmpty(assetPath))
			{
				var config = AssetDatabase.LoadAssetAtPath<AbilityCardConfig>(assetPath);
				if (config != null && _renderer.sprite != config.Sprite)
				{
					_renderer.sprite = config.Sprite;
					Debug.Log($"Sprite set to {_renderer.sprite.name} for {_renderer.name}");
				}
			}
		}
#endif

		private void OnDestroy()
		{
			AdressablesLoadManager.ReleaseAsset(_abilityCardConfigReference);
		}
	}
}