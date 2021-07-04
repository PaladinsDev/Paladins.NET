namespace Paladins.Net
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Paladins.Net.Enumerations;
    using Paladins.Net.Exceptions;
    using Paladins.Net.Interfaces;
    using Paladins.Net.Models;

    /// <summary>
    /// The JSON version of the API.
    /// It returns raw data from the Hi-Rez API and is what provides data <c>API</c>.
    /// </summary>
    public class JsonApi : IJsonApi
    {
        private readonly string devID;
        private readonly string authKey;
        private readonly bool debugMode;
        private readonly string timestamp;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonApi"/> class.
        /// </summary>
        /// <param name="devId">Developer ID.</param>
        /// <param name="authKey">Authorization key.</param>
        /// <param name="timestamp">Timestamp to use.</param>
        /// <param name="apiUrl">API URL to </param>
        /// <param name="debugMode">Adds </param>
        public JsonApi(string devId, string authKey, string timestamp, string apiUrl, bool debugMode = false)
        {
            this.devID = devId;
            this.authKey = authKey;
            this.debugMode = debugMode;
            this.timestamp = timestamp;
            this.ServiceURL = apiUrl;
            this.httpClient = new HttpClient();
        }

        /// <inheritdoc cref="JsonApi"/>
        public JsonApi(string devId, string authKey, string timestamp, Session establishedSession, string apiUrl, bool debugMode = false)
            : this(devId, authKey, timestamp, apiUrl, debugMode)
        {
            if (establishedSession != null)
            {
                this.Session = establishedSession;
            }
        }

        /// <inheritdoc cref="JsonApi"/>
        public JsonApi(string devId, string authKey, string timestamp, JsonDocument establishedSession, string apiUrl, bool debugMode = false)
            : this(devId, authKey, timestamp, apiUrl, debugMode)
        {
            if (establishedSession != null)
            {
                this.Session = new Session
                {
                    ID = establishedSession.RootElement.GetProperty("session_id").GetString(),
                    Data = establishedSession,
                };
            }
        }

        /// <summary>
        /// Gets the current service/API URL.
        /// </summary>
        public string ServiceURL { get; }

        /// <summary>
        /// Gets or sets session.
        /// </summary>
        public Session Session { get; set; }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetChampions(Language language = Language.English)
        {
            return await this.CallEndpointAsync(this.BuildURL("getchampions", null, language));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetChampionCards(int champion, Language language = Language.English)
        {
            return await this.CallEndpointAsync(this.BuildURL("getchampioncards", null, language, 0, champion));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetChampionSkins(int champion, Language language = Language.English)
        {
            return await this.CallEndpointAsync(this.BuildURL("getchampioncards", null, language, 0, champion));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetItems(Language language = Language.English)
        {
            return await this.CallEndpointAsync(this.BuildURL("getitems", null, language));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetCompletedMatchDetails(uint matchID)
        {
            return await this.CallEndpointAsync(this.BuildURL("mycall", null, 0, matchID));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetCompletedMatchDetails(uint[] matchIDs)
        {
            // We're calling it on the player argument just because we need it as a string, that's all. Nothing special.
            return await this.CallEndpointAsync(this.BuildURL("getmatchdetailsbatch", string.Join(',', matchIDs)));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetActiveMatchDetails(uint matchID)
        {
            return await this.CallEndpointAsync(this.BuildURL("getmatchplayerdetails", null, 0, matchID));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayer(uint playerID)
        {
            // TODO DO THIS METHOD
            return await this.CallEndpointAsync(this.BuildURL("mycall"));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayers(uint[] playerIDs)
        {
            return await this.CallEndpointAsync(this.BuildURL("getplayerbatch", string.Join(',', playerIDs)));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerChampionRanks(uint playerID)
        {
            return await this.CallEndpointAsync(this.BuildURL("getchampionranks", playerID.ToString()));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerIDByGamertag(string name, Platform platform)
        {
            return await this.CallEndpointAsync(this.BuildURL("getplayeridsbygamertag", name, 0, 0, 0, Queue.Unknown, 0, 0, platform));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerIDByName(string name)
        {
            return await this.CallEndpointAsync(this.BuildURL("getplayeridbyname", name));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerIDByPlatformUserID(string name, Platform platform)
        {
            return await this.CallEndpointAsync(this.BuildURL("getplayeridbyportaluserid", name, 0, 0, 0, Queue.Unknown, 0, 0, platform));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerIDForXboxAndSwitch(string name)
        {
            return await this.CallEndpointAsync(this.BuildURL("getplateridinfoforxboxandswitch", name));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerLoadouts(uint playerID, Language language)
        {
            return await this.CallEndpointAsync(this.BuildURL("getplayerloadouts", playerID.ToString(), language));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerMatchHistory(uint playerID)
        {
            return await this.CallEndpointAsync(this.BuildURL("getmatchhistory", playerID.ToString()));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerRelationships(uint playerID)
        {
            return await this.CallEndpointAsync(this.BuildURL("mycall"));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerQueueStats(uint playerID, Queue queue)
        {
            return await this.CallEndpointAsync(this.BuildURL("getchampionranks", playerID.ToString(), 0, 0, 0, queue));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetPlayerStatus(uint playerID)
        {
            return await this.CallEndpointAsync(this.BuildURL("getplayerstatus", playerID.ToString()));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetBountyItems()
        {
            return await this.CallEndpointAsync(this.BuildURL("getbountyitems"));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetCurrentDataUsage()
        {
            return await this.CallEndpointAsync(this.BuildURL("getdataused"));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> GetCurrentPatchVersion()
        {
            return await this.CallEndpointAsync(this.BuildURL("getpatchinfo"));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> Ping()
        {
            return await this.CallEndpointAsync(this.BuildURL("ping"));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> TestSession()
        {
            return await this.CallEndpointAsync(this.BuildURL("testsession"));
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> CreateSession(bool setSession = true)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ServiceURL}/createsessionJson/{this.devID}/{Hash("createsession")}/{this.timestamp}");
            using var response = await this.httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadFromJsonAsync<JsonDocument>();

                    if (content.RootElement.GetProperty("ret_msg").GetString().ToLower().Contains("invalid developer"))
                    {
                        return await Task.FromException<JsonDocument>(new UnauthorizedException("The developer ID and authorization key used are invalid."));
                    }

                    if (setSession)
                    {
                        if (content.RootElement.TryGetProperty("session_id", out JsonElement id) &&
                            content.RootElement.TryGetProperty("timestamp", out JsonElement timestamp))
                        {
                            Session = new Session()
                            {
                                ID = id.GetString(),
                                Timestamp = timestamp.GetString()
                            };
                        }
                        else
                        {
                            return await Task.FromException<JsonDocument>(new InvalidSessionException("New session can not be set."));
                        }
                    }

                    return content;
                }
                catch (Exception ex)
                {
                    return await Task.FromException<JsonDocument>(ex);
                }
            }

            throw new System.Exception("Can not create session.");
        }

        /// <inheritdoc/>
        public string BuildURL(
            string method,
            string player = null,
            Language language = default, /* This defaults to 0, I believe. Test this. */
            uint matchID = 0,
            int champion = 0,
            Queue queue = default, /* Same applies here */
            int tier = 0,
            int season = 0,
            Platform platform = default /* Also here */ )
        {
            if (this.Session.ID == null)
            {
                throw new InvalidSessionException("Session ID can not be null");
            }

            string url = $"{this.ServiceURL}/{method}Json/{this.devID}/{this.Hash(method)}/{this.Session.ID}/{this.timestamp}";

            if (platform > 0)
            {
                url += $"/{platform}";
            }

            if (player != null)
            {
                url += $"/{player}";
            }

            if (champion > 0)
            {
                url += $"/{champion}";
            }

            if (language > 0)
            {
                url += $"/{language}";
            }

            if (matchID > 0)
            {
                url += $"/{matchID}";
            }

            if (queue > 0)
            {
                url += $"/{queue}";
            }

            if (tier > 0)
            {
                url += $"/{tier}";
            }

            if (season > 0)
            {
                url += $"/{season}";
            }

            return url;
        }

        /// <inheritdoc/>
        public async Task<JsonDocument> CallEndpointAsync(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            using var response = await this.httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var res = await response.Content.ReadFromJsonAsync<JsonDocument>();

                    if (res.RootElement.GetArrayLength() > 0 &&
                        res.RootElement[0].TryGetProperty("ret_msg", out JsonElement retMsg) &&
                        retMsg.ToString().ToLower().Contains("invalid session id"))
                    {
                        return await Task.FromException<JsonDocument>(new InvalidSessionException("Session is no longer valid."));
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    return await Task.FromException<JsonDocument>(ex);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public string Hash(string method)
        {
            var bytes = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes($"{this.devID}{method}{this.authKey}{this.timestamp}"));
            var str = new System.Text.StringBuilder();

            foreach (var b in bytes)
            {
                str.Append(b.ToString("x2").ToLower());
            }

            return str.ToString();
        }
    }
}
