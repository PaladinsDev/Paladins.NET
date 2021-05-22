using System.Text.Json;
using Paladins.Net.Models;
using System.Threading.Tasks;

namespace Paladins.Net
{
    public class API
    {
        private IJsonAPI _jsonAPI;

        public API(string DevID, string AuthKey, string apiUrl = null, bool DebugMode = false)
        {
            //this._devID = DevID;
            //this._authKey = AuthKey;
            //this._debugMode = DebugMode;
            //this._timestamp = System.DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            // ServiceURL = apiUrl ?? APIStatics.DEFAULT_API_URL;

        }

        public async Task<DataUsage> GetCurrentDataUsage()
        {
            //
        }
    }

    public class APIStatics
    {
        public readonly static string DEFAULT_API_URL = "https://api.paladins.com/paladinsapi.svc";
    }
}
