using System;
using SimpleInjector;
using DomainModel;

namespace CompositionRoot
{
    /// <summary>
    /// This class contains all the custom application bindings.
    /// </summary>
    internal static class CustomBindings
    {
        internal static void Bind(Container container)
        {
            // Put here the bindings of your own custom services

            
                container.Register<
                    Persistence.SQLServer.data.CIRDbContext>(Lifestyle.Scoped);

                container.Register<
                   DomainModel.Services.User.IAuthenticateUser,
                   Persistence.SQLServer.Implementations.User.AuthenticateUser>(Lifestyle.Scoped);
      
                container.Register<
                  DomainModel.Services.User.IGetUsers,
                  Persistence.SQLServer.Implementations.User.GetUsers>(Lifestyle.Scoped);

                container.Register<DomainModel.Services.User.IAddUser,
                    Persistence.SQLServer.Implementations.User.AddUser>(Lifestyle.Scoped);

                container.Register<DomainModel.Services.User.IUpdateUser,
                    Persistence.SQLServer.Implementations.User.UpdateUser>(Lifestyle.Scoped);

                container.Register<DomainModel.Services.User.IDeleteUser,
                    Persistence.SQLServer.Implementations.User.DeleteUser>(Lifestyle.Scoped);
            
        }
    }
}