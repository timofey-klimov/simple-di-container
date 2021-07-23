using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using SimpleDI.Attributes;

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

            var exportAttributeTypes = exportedTypes
                .Where(x => x.GetCustomAttribute<ExportAttribute>() != null)
                .ToList();

            exportAttributeTypes.ForEach(x =>
            {
                var attribute = x.GetCustomAttribute<ExportAttribute>();
                var creationType = x.GetProperties().Where(x => x.GetCustomAttribute<ImportAttribute>() != null).Any() ? InjectionType.Property : InjectionType.Constructor;
                if (attribute.Contract != null)
                {
                    _serviceDescriptors.Add(new ServiceDescriptor(attribute.Contract, x, creationType));
                }
                else
                {
                    _serviceDescriptors.Add(new ServiceDescriptor(x, creationType));
                }
            });

            var importConstructorAttributeTypes = exportedTypes
                .Where(x => x.GetCustomAttribute<ImportConstructorAttribute>() != null)
                .ToList();

            importConstructorAttributeTypes.ForEach(x => _serviceDescriptors.Add(new ServiceDescriptor(x, InjectionType.Constructor)));

            var importPropertyAttributesTypes = exportedTypes
                .Where(x =>
                {
                    if (x.GetProperties().Where(x => x.GetCustomAttribute<ImportAttribute>() != null).Any())
                        return true;
                    return false;
                })
                .ToList();

            importPropertyAttributesTypes.ForEach(x => _serviceDescriptors.Add(new ServiceDescriptor(x, InjectionType.Property)));

            return new ServiceProvider(_serviceDescriptors);
        }

    }
}
