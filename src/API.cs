namespace Paladins.Net
{
    public class API
    {
        private string _devID;
        private string _authKey;
        private bool _debugMode;
        private string _timestamp;
        private string _urlBase;

        public API(string DevID, string AuthKey, bool DebugMode = false, string apiUrl = "https://api.paladins.com/paladinsapi.svc")
        {
            this._devID = DevID;
            this._authKey = AuthKey;
            this._debugMode = DebugMode;
            this._timestamp = System.DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            this._urlBase = apiUrl;
        }
    }
}
