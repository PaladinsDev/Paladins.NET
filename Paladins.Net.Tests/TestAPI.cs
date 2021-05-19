using System;
using Xunit;
using Xunit.Abstractions;

namespace Paladins.Net.Tests
{
    public class TestAPI
    {
        private readonly ITestOutputHelper output;

        public TestAPI(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            output.WriteLine("test");
        }
    }
}
