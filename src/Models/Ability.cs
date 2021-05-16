using Paladins.Net.Enumerations;

namespace Paladins.Net.Models
{
    public class Ability : IModel
    {
        public uint ID { get; set; }
        public int RechargeSeconds { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string DamageTypeName { get; set; }

        private AbilityType _damageType;
        public AbilityType DamageType
        {
            get => this._damageType;

            set
            {
                this._damageType = value.ToString().ToLower() switch
                {
                    "aoe" => AbilityType.AoE,
                    "direct" => AbilityType.Direct_Damage,
                    _ => AbilityType.Undefined
                };
            }
        }
    }
}