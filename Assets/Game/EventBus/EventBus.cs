using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public class EventBus
    {
        private readonly Dictionary<Type, IEventHandlerCollection> _handlers = new();

        private readonly Queue<IEvent> _queue = new();
        private bool _isRunning;

        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            var key = typeof(TEvent);

            if (!_handlers.ContainsKey(key))
            {
                _handlers[key] = new EventHandlerCollection<TEvent>();
            }
            
            _handlers[key].Subscribe(handler);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler)
        {
            var key = typeof(TEvent);
            
            if (_handlers.TryGetValue(key, out var handlers))
            {
                handlers.Unsubscribe(handler);
            }
        }

        public void RaiseEvent<TEvent>(TEvent evt) where TEvent : IEvent
        {
            if (_isRunning)
            {
                _queue.Enqueue(evt);
                return;
            }

            _isRunning = true;
            
            // var key = typeof(TEvent);
            var key = evt.GetType();
            Debug.Log($"Raise event {key.Name}");

            if (_handlers.TryGetValue(key, out var handlers))
            {
                handlers.RaiseEvent(evt);
            }

            _isRunning = false;

            if (_queue.TryDequeue(out var result))
            {
                RaiseEvent(result);
            }
        }
    }
}
