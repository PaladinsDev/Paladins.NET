namespace Paladins.Net.Models
{
    using System.Collections.Generic;
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Champion.
    /// </summary>
    public partial class Champion : PartialChampion
    {
        /// <summary>
        /// Gets or sets role.
        /// </summary>
        public ChampionRole Role { get; set; }

        /// <summary>
        /// Gets or sets title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets lore.
        /// </summary>
        public string Lore { get; set; }

        /// <summary>
        /// Gets or sets icon URL.
        /// </summary>
        public string IconURL { get; set; }

        /// <summary>
        /// Gets or sets health.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets speed.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Gets or sets abilities.
        /// </summary>
        public List<Ability> Abilities { get; set; }
    }
}
