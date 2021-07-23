using SimpleDI.Container;
using SimpleDI.Test;
using System.Reflection;

namespace SimpleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new SimpleContainer(Assembly.GetExecutingAssembly());
           
            var provider = container.BuildServiceProvider();

            var type = provider.CreateInstanse<TestTypeConstructor>();
        }
    }
}
