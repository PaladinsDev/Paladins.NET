using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using Paladins.Net.Enumerations;
using Paladins.Net.Models;
using System.Threading.Tasks;
using Paladins.Net.Interfaces;

namespace Paladins.Net
{
    public class JsonAPI : IJsonAPI
    {
        private string _devID;
        private string _authKey;
        private bool _debugMode;
        private string _timestamp;
        private HttpClient _httpClient;
        public string ServiceURL { get; }
        public Session Session { get; }

        public JsonAPI(string DevID, string AuthKey, string timestamp, string apiUrl = null,  bool DebugMode = false)
        {
            this._devID = DevID;
            this._authKey = AuthKey;
            this._debugMode = DebugMode;
            this._timestamp = timestamp;
            ServiceURL = apiUrl;
            this._httpClient = new HttpClient();
        }

        public JsonAPI(string DevID, string AuthKey, Session establishedSession = null, string apiUrl = null, bool DebugMode = false) : this(DevID, AuthKey, apiUrl, DebugMode)
        {
            if (establishedSession != null)
            {
                this.Session = establishedSession;
            }
        }

        public JsonAPI(string DevID, string AuthKey, JsonDocument establishedSession = null, string apiUrl = null, bool DebugMode = false) : this(DevID, AuthKey, apiUrl, DebugMode)
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
            return await CallEndpointAsync(this.BuildURL("getdataused"), this._httpClient);
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

        public async Task<JsonDocument> CallEndpointAsync(string uri, HttpClient httpClient)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            using var response = await httpClient.SendAsync(request);

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
