namespace Paladins.Net.Models
{
    /// <summary>
    /// Casual player stats.
    /// </summary>
    public class CasualPlayerStats : Model
    {
        /// <summary>
        /// Gets or sets wins.
        /// </summary>
        public uint Wins { get; set; }

        /// <summary>
        /// Gets or sets losses.
        /// </summary>
        public uint Losses { get; set; }

        /// <summary>
        /// Gets or sets leaves.
        /// </summary>
        public uint Leaves { get; set; }
    }
}
