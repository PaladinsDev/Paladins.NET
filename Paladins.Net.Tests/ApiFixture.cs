namespace Paladins.Net.Tests
{
    using System;

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
            //
        }

        /// <summary>
        /// Cleanup.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
