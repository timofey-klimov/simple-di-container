using SimpleDI.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace SimpleDI.Strategy
{
    public class PropertyStrategy : ICreateInstanceStrategy
    {
        public object CreateObject(Type typeToCreate, Func<Type,object> callback)
        {
            var props = typeToCreate
                    .GetProperties()
                    .Where(x => x.GetCustomAttribute<ImportAttribute>() != null)
                    .ToList();

            var objToCreate = Activator.CreateInstance(typeToCreate);

            foreach (var prop in props)
            {
                var obj = callback(prop.PropertyType);

                prop.SetValue(objToCreate, obj);
            }

            return objToCreate;
        }
    }
}
