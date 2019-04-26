using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CQRS.Commands;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetIntSum;
using DomainModel.FakeInterfaces;
using SimpleInjector;

namespace CompositionRoot
{
    public static class RootBindings
    {
        public static void Bind(Container container)
        {
            container.Register<IMyFakeInterface, MyFakeImplementation>(Lifestyle.Scoped);

            var assemblies = new Assembly[]
            {
                typeof(GetIntSumQuery).Assembly
            };

            // The following two lines perform the batch registration by using
            // the great generics support provided by SimpleInjector.
            container.Register(typeof(ICommandHandler<>), assemblies);
            container.Register(typeof(IQueryHandler<,>), assemblies);
        }
    }
}
