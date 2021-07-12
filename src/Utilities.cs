using Paladins.Net.Enumerations;

namespace Paladins.Net
{
    public static class Utilities
    {
        /// <summary>
        /// The default API URL.
        /// </summary>
#pragma warning disable S1075 // URIs should not be hardcoded
        public static readonly string DefaultApiUrl = "https://api.paladins.com/paladinsapi.svc";
#pragma warning restore S1075 // URIs should not be hardcoded

        // TODO: GetChampion method
        // TODO: Create/Make web request

        public static Platform ParsePlatform(string platform)
        {
            switch (platform.ToLower())
            {
                case "pc":
                case "hirez":
                case "standalone":
                    return Platform.HiRez;
                case "steam":
                case "s":
                    return Platform.Steam;
                case "epic":
                case "egs":
                case "epicgames":
                case "eg":
                    return Platform.EpicGames;
                case "psn":
                case "playstation":
                case "ps4":
                case "ps5":
                case "ps":
                    return Platform.PSN;
                case "xbox":
                case "xboxlive":
                case "xbl":
                case "xbox1":
                case "xbox_one":
                case "xboxone":
                case "xb":
                    return Platform.XboxLive;
                case "nintendo":
                case "switch":
                    return Platform.Nintendo;
                case "discord":
                case "d":
                    return Platform.Discord;
                case "mixer":
                    return Platform.Mixer;
                case "facebook":
                case "fb":
                    return Platform.Facebook;
                case "google":
                case "gmail":
                    return Platform.Google;
                default:
                    return Platform.Unknown;
            }
        }
    }
}
