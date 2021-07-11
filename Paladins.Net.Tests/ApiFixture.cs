namespace Paladins.Net.Tests
{
    using System;
    using System.IO;
    using System.Text.Json;

    /// <summary>
    /// Class fixture to persist instances of the API to prevent hitting API and session limits.
    /// </summary>
    public sealed class ApiFixture : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiFixture"/> class.
        /// </summary>
        public ApiFixture()
        {
            string authFile = File.ReadAllText("config\\auth.json");
            this.Auth = JsonSerializer.Deserialize<AuthModel>(authFile);
        }

        /// <summary>
        /// Gets or sets auth.
        /// </summary>
        public AuthModel Auth { get; set; }

        /// <summary>
        /// Cleanup.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
