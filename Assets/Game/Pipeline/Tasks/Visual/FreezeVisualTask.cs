using Entities;
using UnityEngine;

namespace EventBus
{
    public class FreezeVisualTask : EventTask
	{
		private readonly Entity _target;        
        private GameObject _prefab;

		public FreezeVisualTask(Entity target, GameObject prefab)
		{			
			_target = target;
            _prefab = prefab;
		}

		protected override void OnRun()
		{
			Debug.Log("FreezeVisualTask OnRun");
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
            var parentTransform = targetHeroViewComponent.Container;
            var view = GameObject.Instantiate(_prefab, parentTransform.position, Quaternion.identity, parentTransform);
			var freezeComponent = _target.GetData<FrozenComponent>();
            freezeComponent.View = view;
            Finish();
		}
	}
}