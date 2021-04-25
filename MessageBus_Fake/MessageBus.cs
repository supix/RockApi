using DomainModel.Services;
using Serilog;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CompositionRoot")]

namespace MessageBus_Fake
{
    internal class MessageBus : IMessageBus
    {
        public void Send(string topic, string message)
        {
            Log.Information($"[MessageBus] Topic: { topic } - Message: { message }");
        }
    }
}