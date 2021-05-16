using Paladins.Net.Enumerations;

namespace Paladins.Net.Models
{
    public class BountyItem : IModel
    {
        public bool Active { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public PartialChampion Champion { get; set; }
        public string ExpiresAt { get; set; }
        public BountySaleType SaleType { get; set; }
        public int InitialPrice { get; set; }
        public int FinalPrice { get; set; }
    }
}
