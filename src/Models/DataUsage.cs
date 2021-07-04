namespace Paladins.Net.Models
{
    /// <summary>
    /// Data Usage.
    /// </summary>
    public class DataUsage : Model
    {
        /// <summary>
        /// Gets or sets timestamp.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets active sessions.
        /// </summary>
        public uint ActiveSessions { get; set; }

        /// <summary>
        /// Gets or sets active sessions limit.
        /// </summary>
        public uint ActiveSessionsLimit { get; set; }

        /// <summary>
        /// Gets or sets sessions used.
        /// </summary>
        public uint SessionsUsed { get; set; }

        /// <summary>
        /// Gets or sets sessions limit.
        /// </summary>
        public uint SessionsLimit { get; set; }

        /// <summary>
        /// Gets or sets session lifetime.
        /// </summary>
        public int SessionLifetime { get; set; }

        /// <summary>
        /// Gets or sets requests used.
        /// </summary>
        public uint RequestsUsed { get; set; }

        /// <summary>
        /// Gets or sets requests limit.
        /// </summary>
        public uint RequestsLimit { get; set; }
    }
}
