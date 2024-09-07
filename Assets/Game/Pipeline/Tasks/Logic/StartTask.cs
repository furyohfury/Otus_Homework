using UnityEngine;

namespace Lessons.Lesson19_EventBus
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