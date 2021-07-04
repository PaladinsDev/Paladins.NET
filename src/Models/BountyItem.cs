
namespace Paladins.Net.Models
{
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Bounty Item.
    /// </summary>
    public class BountyItem : Model
    {
        /// <summary>
        /// Gets or sets a value indicating whether active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets item ID.
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets champion.
        /// </summary>
        public PartialChampion Champion { get; set; }

        /// <summary>
        /// Gets or sets expires at.
        /// </summary>
        public string ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets sale type.
        /// </summary>
        public BountySaleType SaleType { get; set; }

        /// <summary>
        /// Gets or sets initial price.
        /// </summary>
        public int InitialPrice { get; set; }

        /// <summary>
        /// Gets or sets final price.
        /// </summary>
        public int FinalPrice { get; set; }
    }
}
