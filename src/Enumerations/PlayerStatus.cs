namespace Paladins.Net.Enumerations
{
    /// <summary>
    /// The current state of the player.
    /// </summary>
    public enum PlayerStatus
    {
        /// <summary>
        /// Offline
        /// </summary>
        Offline = 0,

        /// <summary>
        /// In Lobby
        /// </summary>
        In_Lobby = 1,

        /// <summary>
        /// Champion Selection
        /// </summary>
        Champion_Selection = 2,

        /// <summary>
        /// In Match
        /// </summary>
        In_Match = 3,

        /// <summary>
        /// Online
        /// </summary>
        Online = 4,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 5,
    }
}
