namespace Paladins.Net.Models
{
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Ranked player stats.
    /// </summary>
    public class RankedPlayerStats : CasualPlayerStats
    {
        /// <summary>
        /// Gets or sets input mode.
        /// </summary>
        public RankedMode InputMode { get; set; }

        /// <summary>
        /// Gets or sets rank.
        /// </summary>
        public Rank Rank { get; set; }

        /// <summary>
        /// Gets or sets points.
        /// </summary>
        public uint Points { get; set; }

        /// <summary>
        /// Gets or sets season.
        /// </summary>
        public uint Season { get; set; }
    }
}
