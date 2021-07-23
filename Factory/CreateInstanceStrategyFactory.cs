using SimpleDI.Container;
using SimpleDI.Strategy;
using System;

namespace SimpleDI.Factory
{
    public class CreateInstanceStrategyFactory
    {
        public ICreateInstanceStrategy Create(InjectionType injectionType)
        {
            switch (injectionType)
            {
                case InjectionType.Constructor:
                    return new ConstructorStrategy();
                case InjectionType.Property:
                    return new PropertyStrategy();
                default:
                    throw new Exception("Not such strategy");
            }
        }
    }
}
