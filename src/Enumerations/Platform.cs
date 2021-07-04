using System;

namespace Paladins.Net.Enumerations
{
    /// <summary>
    /// The player platform.
    /// </summary>
    public enum Platform
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 9999,

        /// <summary>
        /// Hi-Rez
        /// </summary>
        HiRez = 1,

        /// <summary>
        /// Steam
        /// </summary>
        Steam = 5,

        /// <summary>
        /// Epic Games
        /// </summary>
        EpicGames = 28,

        /// <summary>
        /// PlayStation Network
        /// </summary>
        PSN = 9,

        /// <summary>
        /// Xbox Live
        /// </summary>
        XboxLive = 10,

        /// <summary>
        /// Nintendo
        /// </summary>
        Nintendo = 22,

        /// <summary>
        /// Discord
        /// </summary>
        Discord = 25,

        /// <summary>
        /// Mixer
        /// </summary>
        [Obsolete("Mixer shutdown July 22nd, 2020.")]
        Mixer = 14,

        /// <summary>
        /// Facebook
        /// </summary>
        Facebook = 12,

        /// <summary>
        /// Google
        /// </summary>
        Google = 13,
    }
}
