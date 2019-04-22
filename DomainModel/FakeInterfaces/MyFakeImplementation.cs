using System;
using System.Collections.Generic;
using System.Text;

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
