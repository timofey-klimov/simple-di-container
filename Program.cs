using SimpleDI.Container;
using System;
using System.Reflection;

namespace SimpleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new SimpleContainer(Assembly.GetExecutingAssembly());
            container.AddType<ITestType, TestType>();
            var provider = container.BuildServiceProvider();

            var type = provider.CreateInstanse<ITestType>();
        }
    }
}
