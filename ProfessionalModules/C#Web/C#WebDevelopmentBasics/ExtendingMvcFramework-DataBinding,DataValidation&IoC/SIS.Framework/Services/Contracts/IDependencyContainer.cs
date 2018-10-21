using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Services
{
    public interface IDependencyContainer
    {
        void RegisterDependancy<TSource, TDestination>();

        T CreateInstance<T>();

        object CreateInstance(Type type);
    }
}
