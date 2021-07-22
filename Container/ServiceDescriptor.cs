using System;

namespace SimpleDI.Container
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; private set; }

        public Type ImplementationType { get; private set; }

        public object Implementation { get; private set; }

        public ServiceDescriptor(object impl)
        {
            ServiceType = impl.GetType();
            Implementation = impl;
        }

        public ServiceDescriptor(Type serviceType)
        {
            ServiceType = serviceType;
        }

        public ServiceDescriptor(Type serviceType, Type implType)
        {
            ServiceType = serviceType;
            ImplementationType = implType;
        }
    }
}
