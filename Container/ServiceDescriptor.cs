using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleDI.Container
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; private set; }

        public Type ImplementationType { get; private set; }

        public object Implementation { get; private set; }

        public InjectionType InjectionType { get; private set; }

        public ServiceDescriptor(object impl)
        {
            ServiceType = impl.GetType();
            Implementation = impl;
            InjectionType = InjectionType.Constructor;
        }

        public ServiceDescriptor(Type serviceType)
        {
            ServiceType = serviceType;
            InjectionType = InjectionType.Constructor;
        }

        public ServiceDescriptor(Type serviceType, Type implType, InjectionType injectionType = InjectionType.Constructor)
        {
            ServiceType = serviceType;
            ImplementationType = implType;
            InjectionType = injectionType;
        }

        public ServiceDescriptor(Type serviceType, InjectionType injectionType = InjectionType.Constructor)
        {
            ServiceType = serviceType;
            InjectionType = injectionType;
        }
    }
}
