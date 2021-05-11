using System;
using System.Collections.Generic;
using System.Text;

namespace Paladins.Net.Models
{
    public class DataUsage : IModel
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
}
