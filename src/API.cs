namespace Paladins.Net
{
    public class API
    {
        private string _devID;
        private string _authKey;
        private bool _debugMode;

        public API(string DevID, string AuthKey, bool DebugMode = false)
        {
            this._devID = DevID;
            this._authKey = AuthKey;
            this._debugMode = DebugMode;
        }
    }
}
