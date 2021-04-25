using CQRS.Commands.Notifiers;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AddUser
{
    public class AddUserNotifier : ICommandNotifier<AddUserCommand>
    {
        private readonly IMessageBus messageBus;

        public AddUserNotifier(IMessageBus messageBus)
        {
            this.messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
        }

        public void Notify(AddUserCommand command)
        {
            this.messageBus.Send("userTopic", $"Added user { command.Username }");
        }
    }
}