using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SimpleInjector;

namespace CompositionRoot
{
    public static class RootBindings
    {
        public static void Bind(Container container)
        {
            var assemblies = new Assembly[]
            {
                typeof(DomainModel.CQRS.Queries.GetIntSum.GetIntSumQuery).Assembly
            };

            // The following two lines perform the batch registration by using
            // the great generics support provided by SimpleInjector.
            container.Register(typeof(CQRS.Commands.ICommandHandler<>), assemblies);
            container.Register(typeof(CQRS.Queries.IQueryHandler<,>), assemblies);

            //The following two lines perform the batch registration of the validators
            container.Collection.Register(typeof(CQRS.Commands.Validators.ICommandValidator<>), assemblies);
            container.RegisterDecorator(
                typeof(CQRS.Commands.ICommandHandler<>),
                typeof(CQRS.Commands.Validators.ValidatingCommandHandlerDecorator<>));

            container.RegisterDecorator(
                typeof(CQRS.Queries.IQueryHandler<,>),
                typeof(Logging.CQRS.QueryHandlerLogDecorator<,>));

            container.RegisterDecorator(
                typeof(CQRS.Commands.ICommandHandler<>),
                typeof(Logging.CQRS.CommandHandlerLogDecorator<>));
        }
    }
}
