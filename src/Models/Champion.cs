using System.Collections.Generic;
using Paladins.Net.Enumerations;
using Paladins.Net.Interfaces;

namespace Paladins.Net.Models
{
    public class PartialChampion : IModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public partial class Champion : PartialChampion
    {
        public ChampionRole Role { get; set; }
        public string Title { get; set; }
        public string Lore { get; set; }
        public string IconURL { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Talents> MyProperty { get; set; }
    }

    public class ChampionSkin : IModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PartialChampion Champion { get; set; }
        public Rarity Rarity { get; set; }
    }
}
