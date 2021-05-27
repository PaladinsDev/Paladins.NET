using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using Paladins.Net.Enumerations;
using Paladins.Net.Models;
using System.Threading.Tasks;
using Paladins.Net.Interfaces;
using Paladins.Net.Exceptions;
using System;

namespace Paladins.Net
{
    public class JsonAPI : IJsonAPI
    {
        private readonly string _devID;
        private readonly string _authKey;
        private readonly bool _debugMode;
        private readonly string _timestamp;
        private readonly HttpClient _httpClient;
        public string ServiceURL { get; }
        public Session Session { get; set; }

        public JsonAPI(string devId, string authKey, string timestamp, string apiUrl,  bool debugMode = false)
        {
            this._devID = devId;
            this._authKey = authKey;
            this._debugMode = debugMode;
            this._timestamp = timestamp;
            ServiceURL = apiUrl;
            this._httpClient = new HttpClient();
        }

        public JsonAPI(string devId, string authKey, string timestamp, Session establishedSession, string apiUrl, bool debugMode = false) : this(devId, authKey, timestamp, apiUrl, debugMode)
        {
            if (establishedSession != null)
            {
                this.Session = establishedSession;
            }
        }

        public JsonAPI(string devId, string authKey, string timestamp, JsonDocument establishedSession, string apiUrl, bool debugMode = false) : this(devId, authKey, timestamp, apiUrl, debugMode)
        {
            if (establishedSession != null)
            {
                this.Session = new Session
                {
                    ID = establishedSession.RootElement.GetProperty("session_id").GetString(),
                    Data = establishedSession
                };
            }
        }

        public async Task<JsonDocument> GetChampions(Language language = Language.English)
        {
            return await CallEndpointAsync(this.BuildURL("getchampions", null, language));
        }

        public async Task<JsonDocument> GetChampionCards(Enumerations.Champion champion, Language language = Language.English)
        {
            return await CallEndpointAsync(this.BuildURL("getchampioncards", null, language, 0, champion));
        }

        public async Task<JsonDocument> GetChampionSkins(Enumerations.Champion champion, Language language = Language.English)
        {
            return await CallEndpointAsync(this.BuildURL("getchampioncards", null, language, 0, champion));
        }

        public async Task<JsonDocument> GetItems(Language language = Language.English)
        {
            return await CallEndpointAsync(this.BuildURL("getitems", null, language));
        }

        public async Task<JsonDocument> GetCompletedMatchDetails(uint matchID)
        {
            return await CallEndpointAsync(this.BuildURL("mycall", null, 0, matchID));
        }

        public async Task<JsonDocument> GetCompletedMatchDetails(uint[] matchIDs)
        {
            // We're calling it on the player argument just because we need it as a string, that's all. Nothing special.
            return await CallEndpointAsync(this.BuildURL("getmatchdetailsbatch", string.Join(',', matchIDs)));
        }

        public async Task<JsonDocument> GetActiveMatchDetails(uint matchID)
        {
            return await CallEndpointAsync(this.BuildURL("getmatchplayerdetails", null, 0, matchID));
        }

        public async Task<JsonDocument> GetBountyItems()
        {
            return await CallEndpointAsync(this.BuildURL("getbountyitems"));
        }

        public async Task<JsonDocument> GetCurrentDataUsage()
        {
            return await CallEndpointAsync(this.BuildURL("getdataused"));
        }

        public string BuildURL(
            string method,
            string player = null,
            Language language = default, /* This defaults to 0, I believe. Test this. */
            uint matchID = 0,
            Enumerations.Champion champion = default, /* Same applies here */
            Queue queue = default, /* Same applies here */
            int tier = 0,
            int season = 0,
            Platform platform = default /* Also here */ )
        {
            string url = $"{this.ServiceURL}/{method}Json/{this._devID}/{this.Hash(method)}/{this.Session.ID}/{this._timestamp}";

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

        public async Task<JsonDocument> CallEndpointAsync(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            using var response = await this._httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var res = await response.Content.ReadFromJsonAsync<JsonDocument>();

                    if (res.RootElement.GetArrayLength() > 0 &&
                        res.RootElement[0].TryGetProperty("ret_msg", out JsonElement retMsg) &&
                        retMsg.ToString().ToLower().Contains("invalid session id"))
                    {
                        return await CallEndpointAsync(uri, 0);
                    } else
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

        public async Task<JsonDocument> CallEndpointAsync(string uri, int currentTry, int maxTries = 3)
        {
            if (currentTry < maxTries)
            {
                try
                {
                    var session = await CreateSession(false);

                    if (session.RootElement.TryGetProperty("session_id", out JsonElement id) &&
                        session.RootElement.TryGetProperty("timestamp", out JsonElement timestamp))
                    {
                        Session = new Session()
                        {
                            ID = id.GetString(),
                            Timestamp = timestamp.GetString()
                        };

                        return await CallEndpointAsync(uri);
                    } else
                    {
                        return await CallEndpointAsync(uri, currentTry + 1);
                    }
                } catch (Exception ex) {
                    if (currentTry < maxTries)
                    {
                        return await CallEndpointAsync(uri, currentTry + 1);
                    } else
                    {
                        return await Task.FromException<JsonDocument>(ex);
                    }
                }
            }

            return await Task.FromException<JsonDocument>(new InvalidSessionException("Could not create a new session."));
        }

        public async Task<JsonDocument> CreateSession(bool setSession = true)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ServiceURL}/createsessionJson/{this._devID}/{Hash("createsession")}/{this._timestamp}");
            using var response = await this._httpClient.SendAsync(request);

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
                        } else
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

        public string Hash(string method)
        {
            var bytes = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes($"{this._devID}{method}{this._authKey}{this._timestamp}"));
            var str = new System.Text.StringBuilder();

            foreach (var b in bytes)
            {
                str.Append(b.ToString("x2").ToLower());
            }

            return str.ToString();
        }
    }
}
