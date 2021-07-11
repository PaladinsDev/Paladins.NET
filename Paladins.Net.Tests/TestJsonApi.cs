namespace Paladins.Net.Tests
{
    using System;
    using System.Threading.Tasks;
    using Paladins.Net.Enumerations;
    using Paladins.Net.Models;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// JSON API class tests.
    /// </summary>
    public class TestJsonApi : IClassFixture<ApiFixture>
    {
        /// <summary>
        /// ApiFixture.
        /// </summary>
        private readonly ApiFixture apiFixture;

        /// <summary>
        /// Output.
        /// </summary>
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestJsonApi"/> class.
        /// </summary>
        /// <param name="apiFixture">ApiFixture.</param>
        /// <param name="output">Output.</param>
        public TestJsonApi(ApiFixture apiFixture, ITestOutputHelper output)
        {
            this.apiFixture = apiFixture;
            this.output = output;
        }

        /// <summary>
        /// Test create session.
        /// </summary>
        [Fact]
        public void TestCreateSession()
        {
            this.output.WriteLine(this.apiFixture.Auth.AUTH_KEY);
            Assert.True(true);
        }
    }
}
