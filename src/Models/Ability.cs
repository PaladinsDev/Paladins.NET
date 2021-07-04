namespace Paladins.Net.Models
{
    using Paladins.Net.Enumerations;

    /// <summary>
    /// Champion ability.
    /// </summary>
    public class Ability : Model
    {
        private AbilityType damageType;

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// Gets or sets seconds to recharge.
        /// </summary>
        public int RechargeSeconds { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets URL.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets damage type name.
        /// </summary>
        public string DamageTypeName { get; set; }

        /// <summary>
        /// Gets or sets damage type.
        /// </summary>
        public AbilityType DamageType
        {
            get => this.damageType;

            set => this.damageType = value.ToString().ToLower() switch
            {
                "aoe" => AbilityType.AoE,
                "direct" => AbilityType.Direct_Damage,
                _ => AbilityType.Undefined
            };
        }
    }
}