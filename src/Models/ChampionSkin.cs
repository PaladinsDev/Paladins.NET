namespace Paladins.Net.Models
{
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Champion Skin.
    /// </summary>
    public class ChampionSkin : Model
    {
        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets champion.
        /// </summary>
        public PartialChampion Champion { get; set; }

        /// <summary>
        /// Gets or sets rarity.
        /// </summary>
        public Rarity Rarity { get; set; }
    }
}
