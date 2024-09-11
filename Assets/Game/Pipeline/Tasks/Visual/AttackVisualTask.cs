using Entities;
using UnityEngine;

namespace EventBus
{
	public class AttackVisualTask : EventTask
	{
		private readonly Entity _source;
		private readonly Entity _target;


		public AttackVisualTask(Entity source, Entity target)
		{
			_source = source;
			_target = target;
		}

		protected override async void OnRun()
		{
			Debug.Log("Attack visual task OnRun");
			_source.TryGetData(out HeroViewComponent sourceHeroViewComponent);
			_target.TryGetData(out HeroViewComponent targetHeroViewComponent);

			await sourceHeroViewComponent.HeroView.AnimateAttack(targetHeroViewComponent.HeroView);
			Debug.Log("Attack animation Ended");
			Finish();
		}
	}
}