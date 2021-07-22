using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace SimpleDI.Container
{
    public class SimpleContainer
    {
        private Assembly _assembly;
        private List<ServiceDescriptor> _serviceDescriptors;

        public SimpleContainer(Assembly assembly)
        {
            _assembly = assembly;
            _serviceDescriptors = new List<ServiceDescriptor>();
        }

        public void AddAssembly(Assembly assembly)
        {
            _assembly = assembly;
        }

        public void AddType(object type)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(type));
        }

        public void AddType<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T)));
        }

        public void AddType<TService,TImpl>()
            where TImpl: TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImpl)));
        }
        
        public ServiceProvider BuildServiceProvider()
        {
            var exportedTypes = _assembly.GetExportedTypes();


            return new ServiceProvider(_serviceDescriptors);
        }

    }
}
