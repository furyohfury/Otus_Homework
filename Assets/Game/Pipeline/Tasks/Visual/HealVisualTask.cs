namespace EventBus
{
   public class HealVisualTask : EventTask
	{
		private readonly Entity _target;
        private ParticleSystem _particleSystem;

		public HealVisualTask(Entity target, ParticleSystem particleSystem)
		{
			_target = target;
            _particleSystem = particleSystem;
		}

		protected override void OnRun()
		{
			Debug.Log("HealVisualTask OnRun");
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
			var position = targetHeroViewComponent.HeroView.transform.position;
			var particles = ParticleSystem.Instantiate(_particles, position, Quaternion.identity);
			var psMain = particles.main;
			psMain.stopAction = ParticleSystemStopAction.Destroy;
			particles.Play();
			Finish();
		}
	} 
}
