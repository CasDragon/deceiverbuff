using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using deceiverbuff.Util;
using HarmonyLib;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using System;

namespace deceiverbuff.Content
{
    internal class CheatyMetaMagic
    {
        /*public static void Configure()
        {
            //
        }
        private const string BolsterFeature = "CheatyBolsterFeature";
        private const string BolsterFeatureName = "CheatyBolsterFeature.Name";
        private const string BolsterFeatureDescription = "CheatyBolsterFeature.Description";
        private const string BolsterAbility = "CheatyBolsterAbility";
        private const string BolsterAbilityName = "CheatyBolsterAbility.Name";
        private const string BolsterAbilityDescription = "CheatyBolsterAbility.Description";
        private const string BolsterBuff = "CheatyBolsterBuff";
        private const string BolsterBuffName = "CheatyBolsterBuff.Name";
        private const string BolsterBuffDescription = "CheatyBolsterBuff.Description";
        public static void ConfigureBolster()
        {
            FeatureConfigurator.New(BolsterFeature, Guids.CheatyBolsterMetaMagicFeature)
                .SetDisplayName(BolsterFeatureName)
                .SetDescription(BolsterFeatureDescription)
                .Configure();
            AbilityConfigurator.New(BolsterAbility, Guids.CheatyBolsterMetaMagicAbility)
                .SetDisplayName(BolsterAbilityName)
                .SetDescription(BolsterAbilityDescription)
                .Configure();
            BuffConfigurator.New(BolsterBuff, Guids.CheatyBolsterMetaMagicBuff)
                .SetDescription(BolsterBuffDescription)
                .SetDisplayName(BolsterBuffName)
                .AddAutoMetamagic(metamagic: Metamagic.Bolstered)
                .Configure();
        }*/
    }
    [HarmonyPatch(typeof(MetamagicRodMechanics))]
    internal class MetamagicRodMechanics_Patch
    {
        [HarmonyPatch(nameof(MetamagicRodMechanics.IsSuitableAbility))]
        [HarmonyPostfix]
        public static void IsSuitableAbility_Patch(ref bool __result, AbilityData ability)
        {
            Main.logger.Verbose("Patching MetamagicRodMechanics.IsSuitableAbility");
            try
            {
                if (ability.MagicHackData is not null)
                    __result = true;
            }
            catch (Exception e)
            {
                Main.logger.Error("Error when patching IsSuitableAbility - \n" + e);
            }
        }
    }
}
