namespace Paladins.Net.Models
{
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Player.
    /// </summary>
    public partial class Player : PartialPlayer
    {
        // TODO: Make these a parsed time.

        /// <summary>
        /// Gets or sets when the player registerd.
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets last login.
        /// </summary>
        public string LastLogin { get; set; }

        /// <summary>
        /// Gets or sets title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets avatar.
        /// </summary>
        public PlayerAvatar Avatar { get; set; }

        /// <summary>
        /// Gets or sets loading frame URL.
        /// </summary>
        public string LoadingFrameURL { get; set; }

        /// <summary>
        /// Gets or sets level.
        /// </summary>
        public uint Level { get; set; }

        /// <summary>
        /// Gets or sets playtime.
        /// </summary>
        public uint Playtime { get; set; } // TODO: Make this a class to make it a bit nicer.

        /// <summary>
        /// Gets or sets unlocked champion count.
        /// </summary>
        public uint UnlockedChampionsCount { get; set; }

        /// <summary>
        /// Gets or sets region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets total achievements.
        /// </summary>
        public uint TotalAchievements { get; set; }

        /// <summary>
        /// Gets or sets total experience.
        /// </summary>
        public uint TotalExperience { get; set; }

        /// <summary>
        /// Gets or sets casual.
        /// </summary>
        public CasualPlayerStats Casual { get; set; }

        /// <summary>
        /// Gets or sets ranked keyboard.
        /// </summary>
        public RankedPlayerStats RankedKeyboard { get; set; }

        /// <summary>
        /// Gets or sets ranked controller.
        /// </summary>
        public RankedPlayerStats RankedController { get; set; }
    }
}
