using SIS.Framework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Api
{
    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices(IDependencyContainer dependancyContainer);
    }
}
