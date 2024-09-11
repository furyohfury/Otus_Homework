using UnityEngine;

namespace EventBus
{
    public sealed class FinishTask : EventTask
    {
        protected override void OnRun()
        {
            Debug.Log("Finish task on run");
            Finish();
        }
    }
}