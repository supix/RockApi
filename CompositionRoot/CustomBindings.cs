using System;
using SimpleInjector;

namespace CompositionRoot
{
    /// <summary>
    /// This class contains all the custom application bindings.
    /// </summary>
    internal static class CustomBindings
    {
        internal static void Bind(Container container)
        {
            bool useFakeDatabase = false;
            if (useFakeDatabase)
            {
                var fakeDatabase = new Persistence_FakeDatabase.UserFakeDatabase();
                container.Register<DomainModel.Services.IAddUser>(() => fakeDatabase);
                container.Register<DomainModel.Services.IGetUsers>(() => fakeDatabase);
            }
            else
            {
                var mongoDatabase = new Persistence_MongoDB.Database();
                container.Register<DomainModel.Services.IAddUser>(() => mongoDatabase);
                container.Register<DomainModel.Services.IGetUsers>(() => mongoDatabase);
            }

            const bool someConfigurationParameter = true;
            if (someConfigurationParameter)
                container.Register<DomainModel.Services.ILoggedUserHasWritePermissions,
                    Persistence_FakeDatabase.LoggedUserHasWritePermissions_AlwaysTrue>();
            else
                container.Register<DomainModel.Services.ILoggedUserHasWritePermissions,
                    Persistence_FakeDatabase.LoggedUserHasWritePermissions_AlwaysFalse>();

            container.Register<DomainModel.Services.IMessageBus,
                MessageBus_Fake.MessageBus>();
        }
    }
}