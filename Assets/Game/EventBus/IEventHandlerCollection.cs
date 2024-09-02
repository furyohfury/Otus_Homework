using System;

namespace Lessons.Lesson19_EventBus
{
    public interface IEventHandlerCollection
    {
        void Subscribe<TEvent>(Action<TEvent> handler);
        void Unsubscribe<TEvent>(Action<TEvent> handler);
        void RaiseEvent<TEvent>(TEvent evt);
    }
}