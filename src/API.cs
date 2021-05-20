using Paladins.Net.Enumerations;
using Paladins.Net.Interfaces;
using Paladins.Net.Models;

namespace Paladins.Net
{
    public class API
    {
        private string _devID;
        private string _authKey;
        private bool _debugMode;
        private string _timestamp;
        public string ServiceURL { get; set; }

        public API(string DevID, string AuthKey, bool DebugMode = false, string apiUrl = "https://api.paladins.com/paladinsapi.svc")
        {
            this._devID = DevID;
            this._authKey = AuthKey;
            this._debugMode = DebugMode;
            this._timestamp = System.DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            this.ServiceURL = apiUrl;
        }

        private string BuildURL(
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

        private string Hash(string method)
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
