using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.FakeInterfaces;
using SimpleInjector;

namespace CompositionRoot
{
    public static class RootBindings
    {
        public static void Bind(Container container)
        {
            container.Register<IMyFakeInterface, MyFakeImplementation>(Lifestyle.Scoped);
        }
    }
}
