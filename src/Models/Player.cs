namespace Paladins.Net.Models
{
    public class PartialPlayer : IModel
    {
        public uint ID { get; set; }
    }

    public partial class Player : PartialPlayer
    {
    }
}
