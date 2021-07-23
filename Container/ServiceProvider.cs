using SimpleDI.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleDI.Container
{
    public class ServiceProvider
    {
        private ICollection<ServiceDescriptor> _serviceDescriptors;
        public ServiceProvider(ICollection<ServiceDescriptor> descriptors)
        {
            _serviceDescriptors = descriptors;
        }

        public T CreateInstanse<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type service)
        {
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == service);

            if (descriptor == null)
                throw new Exception($"No such type registred {service}");

            var typeToCreate = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (typeToCreate.IsAbstract || typeToCreate.IsInterface)
                throw new Exception("Cannot create instanse of abstract class or interface");

            var fabric = new CreateInstanceStrategyFactory();
            var instanseCreator = fabric.Create(descriptor.InjectionType);

            return instanseCreator.CreateObject(typeToCreate, GetService);
        } 
    }
}
