using EasyNetQ;
using EventBus;
using System;

namespace EventBusRabbitMQ
{
    public class RabbitMQEventBus : EventBus.IEventBus
    {
        private readonly IBus _bus;

        public RabbitMQEventBus(string host, string username, string password)
        {
            _bus = RabbitHutch.CreateBus($"host={host};username={username};password={password}");
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent
            => _bus.Publish(@event);

        public void Subscribe<TEvent>(string queueName, Action<TEvent> eventHandler) where TEvent : class, IEvent
            => _bus.Subscribe(queueName, eventHandler);
    }
}