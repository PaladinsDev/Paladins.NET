using Paladins.Net.Enumerations;

namespace Paladins.Net.Models
{
    public class PartialPlayer : Model
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public Platform Platform { get; set; }
    }

    public partial class Player : PartialPlayer
    {
        // TODO: Make these a parsed time.
        public string CreatedAt { get; set; }
        public string LastLogin { get; set; }
        public string Title { get; set; }
        public PlayerAvatar Avatar { get; set; }
        public string LoadingFrameURL { get; set; }
        public uint Level { get; set; }
        public uint Playtime { get; set; } // TODO: Make this a class to make it a bit nicer.
        public uint UnlockedChampionsCount { get; set; }
        public Region Region { get; set; }
        public uint TotalAchievements { get; set; }
        public uint TotalExperience { get; set; }
        public CasualPlayerStats Casual { get; set; }
        public RankedPlayerStats RankedKeyboard { get; set; }
        public RankedPlayerStats RankedController { get; set; }
    }

    public class PlayerAvatar : Model
    {
        public uint ID { get; set; }
        public string URL { get; set; }
    }

    public class CasualPlayerStats : Model
    {
        public uint Wins { get; set; }
        public uint Losses { get; set; }
        public uint Leaves { get; set; }
    }

    public class RankedPlayerStats : CasualPlayerStats
    {
        public RankedMode InputMode { get; set; }
        public Rank Rank { get; set; }
        public uint Points { get; set; }
        public uint Season { get; set; }
    }

    public class ChampionStats : Model
    {
        public uint Wins { get; set; }
        public uint Losses { get; set; }
        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public uint Assists { get; set; }
        public uint Queue { get; set; }
        public uint Level { get; set; }
        public uint Experience { get; set; }
        public uint TotalCreditsEarned { get; set; }
        public uint Playtime { get; set; }
        public string LastPlayed { get; set; }
        public PartialPlayer Player { get; set; }
        public PartialChampion Champion { get; set; }
    }
}
