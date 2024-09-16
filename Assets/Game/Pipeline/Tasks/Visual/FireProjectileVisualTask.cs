using DG.Tweening;
using EventBus;
using UnityEngine;

namespace Entities
{
	public class FireProjectileVisualTask : EventTask
	{
		private readonly Entity _source;
		private readonly Entity _target;
		private GameObject _projectile;
		private Transform _worldTransform;


		public FireProjectileVisualTask(Entity source, Entity target, GameObject projectile, Transform worldTransform)
		{
			_source = source;
			_target = target;
			_projectile = projectile;
			_worldTransform = worldTransform;
		}

		protected override void OnRun()
		{
			Debug.Log("ThrowProjectileVisualTask OnRun");
			var sourceHeroViewComponent = _source.GetData<HeroViewComponent>();
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
			var startPos = sourceHeroViewComponent.Container.position;
			var endPos = targetHeroViewComponent.Container.position;
			
			var projectile = GameObject.Instantiate(_projectile, startPos, Quaternion.identity, _worldTransform);
			projectile.transform.DOMove(endPos, 1f).OnComplete(() =>
			{
				GameObject.Destroy(projectile);
				Finish();
			});
		}
	}
}