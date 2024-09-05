using Entities;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
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
			Debug.Log("Attack visual task");
			_source.TryGetData(out HeroViewComponent sourceHeroViewComponent);
			_target.TryGetData(out HeroViewComponent targetHeroViewComponent);

			await sourceHeroViewComponent.HeroView.AnimateAttack(targetHeroViewComponent.HeroView);
			Debug.Log("ATTACK ANIM FINISHED");
			Finish();
		}
	}
}