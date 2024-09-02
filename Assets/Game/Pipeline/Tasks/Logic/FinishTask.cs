using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public sealed class FinishTask : EventTask
    {
        protected override void OnRun()
        {
            Debug.Log("Run finish task");
            Finish();
        }
    }
}