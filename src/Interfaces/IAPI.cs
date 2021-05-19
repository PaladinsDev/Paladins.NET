using System.Collections.Generic;
using Paladins.Net.Enumerations;
using Paladins.Net.Models;

namespace Paladins.Net.Interfaces
{
    // TODO: Fix all of this to respond correctly.
    // TODO: Look at other libraries to see if there is stuff I'm missing here.
    public interface IAPI
    {
        public string GetServiceURL();
        public PartialMatch GetActiveMatch(int matchID);
        public void GetMatch(int matchID); // TODO: Fix this. No void. Also...getMatchModeDetails and getMatchDetails? Clarify this one...
        public void GetMatches(int[] matchIDs); // TODO: Fix this. No void. Also, make sure to return as a sorted set of Match IDs based on a list or Map (k->v)
        public void GetMatchIDs(string hour, string date, Queue queue); // TODO: Fix this. No void. Also, this formatting is weird. Make this better in general? Maybe a better name?
        public void GetItems(); // TODO: Fix this. No void.
        public void GetDataUsage(); // TODO: Fix this. No void.
        public void GetChampions(); // TODO: Fix this. No void.
        public void GetChampionSkins(int championID); // TODO: Fix this. No void.
        public void GetChampionCards(int championID); // TODO: Fix this. No void.
        public List<BountyItem> GetBountyItems();
        public List<PartialPlayer> SearchForPlayer(string name);
        public PlayerStatus GetPlayerStatus(int playerID);
        public void GetPlayerRelationships(int playerID); // TODO: Fix this. No void.
        public void GetPlayerQueueStats(int playerID, Queue queue); // TODO: Fix this. No void.
        public List<PartialMatch> GetPlayerMatchHistory(int playerID); // TODO: check this return type.
        public void GetPlayerLoadouts(int playerID); // TODO: Fix this. No void.
        public void GetPlayerIDsByGamertag(string name, Platform platform); // TODO: Fix this. No void.
        public void GetPlayerIDInfoForXboxAndSwitch(string name); // TODO: Fix this. No void.
        public void GetPlayerIDByPlatformUserID(string name, Platform platform); // TODO: Fix this. No void.
        public void GetPlayerIDByName(string name); // TODO: Fix this. No void.
        public void GetPlayerChampionRanks(int playerID); // TODO: Fix this. No void.
        public void GetPlayer(int playerID); // TODO: Fix this. No void.
        public void GetPlayers(int playerIDs);

    }
}
