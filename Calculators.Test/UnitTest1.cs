using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace Calculators.Test
{

    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
                this.output = output;
        }

        [Theory]
        [InlineData("add", 3, 4, "7")]
        [InlineData("subtract", 3, 4, "-1")]
        [InlineData("multiply", 3, 4, "12")]
        [InlineData("divide", 12, 4, "3")]
        [InlineData("divide", 12, 0, "Exception :- Divide by 0")]
        public void TestRun(string oper, int x, int y, string expected)
        {
            Assert.Equal(expected, Solution.Run(oper,x, y));
            output.WriteLine(Solution.Run(oper, x, y));
        }
    }
}