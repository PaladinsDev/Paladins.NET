namespace Paladins.Net.Models
{
    /// <summary>
    /// Champion stats.
    /// </summary>
    public class ChampionStats : Model
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
        /// Gets or sets kills.
        /// </summary>
        public uint Kills { get; set; }

        /// <summary>
        /// Gets or sets deaths.
        /// </summary>
        public uint Deaths { get; set; }

        /// <summary>
        /// Gets or sets assists.
        /// </summary>
        public uint Assists { get; set; }

        /// <summary>
        /// Gets or sets queue.
        /// </summary>
        public uint Queue { get; set; }

        /// <summary>
        /// Gets or sets level.
        /// </summary>
        public uint Level { get; set; }

        /// <summary>
        /// Gets or sets experience.
        /// </summary>
        public uint Experience { get; set; }

        /// <summary>
        /// Gets or sets total credits earned.
        /// </summary>
        public uint TotalCreditsEarned { get; set; }

        /// <summary>
        /// Gets or sets playtime.
        /// </summary>
        public uint Playtime { get; set; }

        /// <summary>
        /// Gets or sets last played.
        /// </summary>
        public string LastPlayed { get; set; }

        /// <summary>
        /// Gets or sets player.
        /// </summary>
        public PartialPlayer Player { get; set; }

        /// <summary>
        /// Gets or sets champion.
        /// </summary>
        public PartialChampion Champion { get; set; }
    }
}
