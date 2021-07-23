using SimpleDI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Test
{
    [ImportConstructor]
    public class TestTypeConstructor
    {
        public ITestType TestType { get; set; }
        public TestTypeConstructor(ITestType testType)
        {
            TestType = testType;
        }
    }
}
