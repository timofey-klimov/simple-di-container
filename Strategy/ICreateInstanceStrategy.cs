using System;

namespace SimpleDI.Strategy
{
    public interface ICreateInstanceStrategy
    {
        object CreateObject(Type typeToCreate, Func<Type, object> callback);
    }
}
