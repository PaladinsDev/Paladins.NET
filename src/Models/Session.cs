namespace Paladins.Net.Models
{
    using System.Text.Json;

    /// <summary>
    /// Session.
    /// </summary>
    public class Session : Model
    {

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets timestamp.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets data.
        /// </summary>
        public JsonDocument Data { get; set; }
    }
}
