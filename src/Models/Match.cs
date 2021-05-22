using Paladins.Net.Enumerations;

namespace Paladins.Net.Models
{
    public class PartialMatch : Model
    {
        public uint ID { get; set; }
        public Queue Queue { get; set; }
        public Region Region { get; set; }
        public string Timestamp { get; set; }
        public uint Duration { get; set; }
        public string MapName { get; set; }
        public (int Team1, int Team2) Score { get; set; }
        public int WinningTeam { get; set; }
        public PartialPlayer Player { get; set; }
        public PartialChampion Champion { get; set; }

    }

    public partial class Match : PartialMatch
    {
    }

    public partial class MatchPlayer : PartialPlayer
    {
    }
}
