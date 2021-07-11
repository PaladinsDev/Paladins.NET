namespace Paladins.Net.Models
{
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Partial player.
    /// </summary>
    public class PartialPlayer : Model
    {
        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets platform.
        /// </summary>
        public Platform Platform { get; set; }
    }
}
