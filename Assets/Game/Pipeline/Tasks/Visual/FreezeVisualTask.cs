namespace Pipeline
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

		protected override async void OnRun()
		{
			Debug.Log("FreezeVisualTask OnRun");
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
            var parentTransform = targetHeroViewComponent.transform;
            var view = GameObject.Instantiate(_prefab, targetHeroViewComponent.parentTransform.position, Quaternion.identity, parentTransform);
			var freezeComponent = _target.GetData<FreezeComponent>();
            freezeComponent.View = view;
            Finish();
		}
	}
}