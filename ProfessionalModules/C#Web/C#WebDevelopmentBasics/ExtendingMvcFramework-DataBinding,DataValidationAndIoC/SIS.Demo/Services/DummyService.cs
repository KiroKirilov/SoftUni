using SIS.Demo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Demo.Services
{
    public class DummyService : IDummyService
    {
        public string DoSomething()
        {
            return "Howdy";
        }
    }
}
