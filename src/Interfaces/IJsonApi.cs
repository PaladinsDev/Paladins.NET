namespace Paladins.Net.Interfaces
{
    using System.Text.Json;
    using System.Threading.Tasks;
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Interface for JSON API.
    /// </summary>
    public interface IJsonApi
    {
        /// <summary>
        /// Build a URL to call the API.
        /// </summary>
        /// <param name="method">Action to call.</param>
        /// <param name="player">Player.</param>
        /// <param name="language">Language.</param>
        /// <param name="matchID">Match ID.</param>
        /// <param name="champion">Champion.</param>
        /// <param name="queue">Queue.</param>
        /// <param name="tier">Tier.</param>
        /// <param name="season">Season.</param>
        /// <param name="platform">Platform.</param>
        /// <returns>A string with a built URL to use with <c>CallEndpointAsync</c>.</returns>
        string BuildURL(string method, string player = null, Language language = 0, uint matchID = 0, int champion = 0, Queue queue = Queue.Unknown, int tier = 0, int season = 0, Platform platform = 0);

        /// <summary>
        /// Call a URL.
        /// </summary>
        /// <param name="uri">URL to call.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> CallEndpointAsync(string uri);

        /// <summary>
        /// Create a new session.
        /// </summary>
        /// <param name="setSession">Persist the session, or just create it.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> CreateSession(bool setSession = true);

        /// <summary>
        /// Get a current on going match's details.
        /// </summary>
        /// <param name="matchID">Match ID.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetActiveMatchDetails(uint matchID);

        /// <summary>
        /// Get all the bounty items.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetBountyItems();

        /// <summary>
        /// Get a champion's cards.
        /// </summary>
        /// <param name="champion">Champion.</param>
        /// <param name="language">Language.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetChampionCards(int champion, Language language = Language.English);

        /// <summary>
        /// Get all the champions available within the game.
        /// </summary>
        /// <param name="language">Language.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetChampions(Language language = Language.English);

        /// <summary>
        /// Get a champion's skins.
        /// </summary>
        /// <param name="champion">Champion.</param>
        /// <param name="language">Language.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetChampionSkins(int champion, Language language = Language.English);

        /// <summary>
        /// Get a completed match's details.
        /// </summary>
        /// <param name="matchID">Match ID.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetCompletedMatchDetails(uint matchID);

        /// <summary>
        /// Get multiple completed match's details.
        /// </summary>
        /// <param name="matchIDs">Match IDs</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetCompletedMatchDetails(uint[] matchIDs);

        /// <summary>
        /// Get the current data usage.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetCurrentDataUsage();

        /// <summary>
        /// Get the current patch version.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetCurrentPatchVersion();

        /// <summary>
        /// Get all the available in match items.
        /// </summary>
        /// <param name="language">Language.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> GetItems(Language language = Language.English);
        Task<JsonDocument> GetPlayer(uint playerID);
        Task<JsonDocument> GetPlayerChampionRanks(uint playerID);
        Task<JsonDocument> GetPlayerIDByGamertag(string name, Platform platform);
        Task<JsonDocument> GetPlayerIDByName(string name);
        Task<JsonDocument> GetPlayerIDByPlatformUserID(string name, Platform platform);
        Task<JsonDocument> GetPlayerIDForXboxAndSwitch(string name);
        Task<JsonDocument> GetPlayerLoadouts(uint playerID, Language language);
        Task<JsonDocument> GetPlayerMatchHistory(uint playerID);
        Task<JsonDocument> GetPlayerQueueStats(uint playerID, Queue queue);
        Task<JsonDocument> GetPlayerRelationships(uint playerID);
        Task<JsonDocument> GetPlayers(uint[] playerIDs);
        Task<JsonDocument> GetPlayerStatus(uint playerID);

        /// <summary>
        /// Calculates an MD5 hash based on the method, dev ID, and auth key.
        /// </summary>
        /// <param name="method">Method.</param>
        /// <returns>An MD5 to use for authorization in calls.</returns>
        string Hash(string method);

        /// <summary>
        /// Ping the API.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> Ping();

        /// <summary>
        /// Test a session.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JsonDocument> TestSession();
    }
}
