using System;

namespace EventBus
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(string queueName, Action<TEvent> eventHandler) where TEvent : class, IEvent;

        void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}