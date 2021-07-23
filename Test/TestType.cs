using SimpleDI.Attributes;

namespace SimpleDI.Test
{
    [Export(typeof(ITestType))]
    public class TestType : ITestType
    {
        [Import]
        public TestTypeProperty TestTypeProperty { get; set; }
    }

}
