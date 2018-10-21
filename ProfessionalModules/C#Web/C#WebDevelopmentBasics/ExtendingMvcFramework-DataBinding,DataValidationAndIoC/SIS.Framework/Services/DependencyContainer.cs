using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SIS.Framework.Services
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> dependancyDictionary;

        public DependencyContainer()
        {
            this.dependancyDictionary = new Dictionary<Type, Type>();
        }

        private Type this[Type key] => this.dependancyDictionary.ContainsKey(key) ? this.dependancyDictionary[key] : null;

        public T CreateInstance<T>()
        {
            return (T)this.CreateInstance(typeof(T));
        }

        public object CreateInstance(Type type)
        {
            Type instanceType = this[type] ?? type;

            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new InvalidOperationException($"Type {instanceType.Name} cannot be instantiated.");
            }

            ConstructorInfo constructor = instanceType.GetConstructors().OrderBy(x => x.GetParameters().Length).First();
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            object[] constructorParameterObjects = new object[constructorParameters.Length];

            for (int i = 0; i < constructorParameters.Length; i++)
            {
                constructorParameterObjects[i] = this.CreateInstance(constructorParameters[i].ParameterType);
            }

            return constructor.Invoke(constructorParameterObjects);
        }

        public void RegisterDependancy<TSource, TDestination>()
        {
            this.dependancyDictionary[typeof(TSource)] = typeof(TDestination);
        }
    }
}
