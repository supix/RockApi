namespace DomainModel.Services
{
    public interface IMessageBus
    {
        void Send(string topic, string message);
    }
}