using System.Text.Json;

namespace Paladins.Net.Models
{
    public class DataUsage : Model
    {
        public string Timestamp { get; set; }
        public uint ActiveSessions { get; set; }
        public uint ActiveSessionsLimit { get; set; }
        public uint SessionsUsed { get; set; }
        public uint SessionsLimit { get; set; }
        public int SessionLifetime { get; set; }
        public uint RequestsUsed { get; set; }
        public uint RequestsLimit { get; set; }
    }

    public class Session : Model
    {
        public string ID { get; set; }
        public JsonDocument Data { get; set; }
    }
}
