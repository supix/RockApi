using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CompositionRoot")]
[assembly: InternalsVisibleTo("DomainModel.Test")]
namespace DomainModel.FakeInterfaces
{
    class MyFakeImplementation : IMyFakeInterface
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
