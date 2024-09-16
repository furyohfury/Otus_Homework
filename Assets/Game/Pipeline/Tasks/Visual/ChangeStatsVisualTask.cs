using Entities;
using UnityEngine;

namespace EventBus
{
   public class ChangeStatsVisualTask : EventTask
	{
		private readonly Entity _target;

		public ChangeStatsVisualTask(Entity target)
		{
			_target = target;
		}

		protected override void OnRun()
		{
			Debug.Log("ChangeStatsVisualTask OnRun");
			var stats = _target.GetData<StatsComponent>();
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
			targetHeroViewComponent.HeroView.SetStats($"{stats.Damage}/{stats.CurrentHealth}");
			Finish();
		}
	} 
}
