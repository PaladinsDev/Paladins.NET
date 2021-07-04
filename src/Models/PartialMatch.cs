namespace Paladins.Net.Models
{
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Partial Match.
    /// </summary>
    public class PartialMatch : Model
    {
        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// Gets or sets queue.
        /// </summary>
        public Queue Queue { get; set; }

        /// <summary>
        /// Gets or sets region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets timestamp.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets duration.
        /// </summary>
        public uint Duration { get; set; }

        /// <summary>
        /// Gets or sets map name.
        /// </summary>
        public string MapName { get; set; }

        /// <summary>
        /// Gets or sets score.
        /// </summary>
        public (int Team1, int Team2) Score { get; set; }

        /// <summary>
        /// Gets or sets winning team.
        /// </summary>
        public int WinningTeam { get; set; }

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
