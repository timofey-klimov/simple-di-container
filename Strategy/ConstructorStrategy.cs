using System;
using System.Linq;

namespace SimpleDI.Strategy
{
    public class ConstructorStrategy : ICreateInstanceStrategy
    {
        public object CreateObject(Type typeToCreate, Func<Type, object> callback)
        {
            var @params = typeToCreate
                    .GetConstructors()
                    .First()
                    .GetParameters()
                    .Select(x => callback(x.ParameterType))
                    .ToArray();

            if (!@params.Any())
                return Activator.CreateInstance(typeToCreate);

            return Activator.CreateInstance(typeToCreate, @params);
        }
    }
}
