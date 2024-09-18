using UnityEngine;

namespace EventBus
{
	public sealed class StartTask : EventTask
	{
		protected override void OnRun()
		{
			Debug.Log("Start task OnRun");
			Finish();
		}
	}
}