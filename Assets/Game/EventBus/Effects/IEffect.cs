using Entities;

namespace Lessons.Lesson19_EventBus
{
    public interface IEffect : IEvent
    {
        Entity Source { get; set; }
        Entity Target { get; set;  }
    }
}