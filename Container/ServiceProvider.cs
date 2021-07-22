using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleDI.Container
{
    public class ServiceProvider
    {
        private List<ServiceDescriptor> _serviceDescriptors;
        public ServiceProvider(List<ServiceDescriptor> descriptors)
        {
            _serviceDescriptors = descriptors;
        }

        public T CreateInstanse<T>()
        {
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == typeof(T));

            if (descriptor == null)
                throw new Exception($"Service {typeof(T).Name} not registred");

            if (descriptor.Implementation != null)
                return (T)descriptor.Implementation;

            var typeToCreate = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (typeToCreate.IsAbstract || typeToCreate.IsInterface)
                throw new Exception("Cannot create instanse of abstract class or inteface");


            var constructor = typeToCreate
                .GetConstructors()
                .First();



            return default;
        }
    }
}
