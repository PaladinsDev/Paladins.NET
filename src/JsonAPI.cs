using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using Paladins.Net.Enumerations;
using Paladins.Net.Models;
using System.Threading.Tasks;
using Paladins.Net.Interfaces;
using Paladins.Net.Exceptions;

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
        public Session Session { get; }

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
            string url = $"{this.ServiceURL}/{method}Json/{this._devID}/{this.Hash(method)}/{this.Session}/{this._timestamp}";

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
                    return await response.Content.ReadFromJsonAsync<JsonDocument>();
                }
                catch (HttpRequestException)
                {
                    //
                }
            }

            return null;
        }

        public async Task<JsonDocument> CreateSession()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ServiceURL}/createsessionJson/{this._devID}/{Hash("createsession")}/{this._timestamp}");
            using var response = await this._httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    using var content = await response.Content.ReadFromJsonAsync<JsonDocument>();

                    return content;
                }
                catch (HttpRequestException)
                {
                    //
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
