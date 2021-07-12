namespace Paladins.Net.Tests
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Paladins.Net.Models;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Class fixture to persist instances of the API to prevent hitting API and session limits.
    /// </summary>
    public sealed class ApiFixture : IAsyncLifetime
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
        /// Gets or sets API.
        /// </summary>
        public API Api { get; set; }

        /// <summary>
        /// Gets or sets JSON API.
        /// </summary>
        public JsonApi JsonApi { get; set; }

        /// <summary>
        /// Initialize Async.
        /// </summary>
        /// <returns>Completed Task.</returns>
        public async Task InitializeAsync()
        {
            if (this.Auth.SESSION_KEY != null)
            {
                this.JsonApi = new JsonApi(
                    this.Auth.DEV_ID,
                    this.Auth.AUTH_KEY,
                    System.DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
                    new Session
                    {
                        ID = this.Auth.SESSION_KEY,
                    }, Utilities.DefaultApiUrl);
            }
            else
            {
                this.JsonApi = new JsonApi(
                    this.Auth.DEV_ID,
                    this.Auth.AUTH_KEY,
                    System.DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
                    Utilities.DefaultApiUrl);
                _ = await this.JsonApi.CreateSession(true);
            }
        }

        /// <summary>
        /// Dispose Async.
        /// </summary>
        /// <returns>Completed Task.</returns>
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
