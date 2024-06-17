using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using HarmonyLib;
using Kingmaker.UnitLogic;
using static Kingmaker.Blueprints.Classes.Spells.SuppressSpellSchool;

namespace deceiverbuff.Content
{
    internal class SpellList
    {
        public static void Configure()
        {
            Main.logger.Info("Starting Spelllist Configure");
            // todo
            // Black Tentacles, Infernal Healing
            AddToList(6, AbilityRefs.HellfireRay.Reference.Get());
            AddToList(1, AbilityRefs.MagicMissile.Reference.Get());
            AddToList(9, AbilityRefs.EnergyDrain.Reference.Get());
            AddToList(1, AbilityRefs.IllOmen.Reference.Get());
            AddToList(2, AbilityRefs.Glitterdust.Reference.Get());
            AddToList(8, AbilityRefs.PolarRay.Reference.Get());
            AddToList(7, AbilityRefs.WavesOfExhaustion.Reference.Get());
            AddToList(5, AbilityRefs.WavesOfFatigue.Reference.Get());
            AddToList(6, AbilityRefs.TidalWaveAbility.Reference.Get());
            AddToList(2, AbilityRefs.AngelicAspect.Reference.Get());
            AddToList(6, AbilityRefs.AngelicAspectGreater.Reference.Get());
            AddToList(3, AbilityRefs.Heroism.Reference.Get());
            AddToList(6, AbilityRefs.HeroismGreater.Reference.Get());
            AddToList(2, AbilityRefs.FalseLife.Reference.Get());
            AddToList(4, AbilityRefs.FalseLifeGreater.Reference.Get());
            AddToList(1, AbilityRefs.MagicWeaponPrimary.Reference.Get());
            AddToList(1, AbilityRefs.MagicWeaponSecondary.Reference.Get());
            AddToList(3, AbilityRefs.MagicWeaponGreaterPrimary.Reference.Get());
            AddToList(3, AbilityRefs.MagicWeaponGreaterSecondary.Reference.Get());
            AddToList(3, AbilityRefs.Haste.Reference.Get());
            AddToList(2, AbilityRefs.ProtectionFromEvilCommunal.Reference.Get());
            AddToList(2, AbilityRefs.ProtectionFromChaosCommunal.Reference.Get());
            AddToList(6, AbilityRefs.FormOfTheDragonIGold.Reference.Get());
            AddToList(6, AbilityRefs.FormOfTheDragonIRed.Reference.Get());
            AddToList(0, AbilityRefs.AcidSplash.Reference.Get());
            AddToList(0, AbilityRefs.RayOfFrost.Reference.Get());
            AddToList(0, AbilityRefs.Jolt.Reference.Get());
            AddToList(7, AbilityRefs.FormOfTheDragonIIGold.Reference.Get());
            AddToList(7, AbilityRefs.FormOfTheDragonIIRed.Reference.Get());
            AddToList(8, AbilityRefs.FormOfTheDragonIIIGold.Reference.Get());
            AddToList(8, AbilityRefs.FormOfTheDragonIIIRed.Reference.Get());
            Main.logger.Info("Completed Spelllist Configure");
        }
        public static void  AddToList(int level, BlueprintAbility spell)
        {
            Main.logger.Verbose("Adding" + spell.NameSafe() + "to Deceiver");
            AbilityConfigurator.For(spell)
                .AddToSpellList(level, SpellListRefs.MagicDeceiverSpellList.Reference.Get())
                .Configure();
        }

        [HarmonyPatch(typeof(CopyScroll))]
        static class CopyScroll_Patch
        {
            [HarmonyPatch(nameof(CopyScroll.CanCopySpell)), HarmonyPostfix]
            static bool DeceiverScollPatch(BlueprintAbility spell, Spellbook spellbook, ref bool __result)
            {
                Main.logger.Info("Patching CanCopyScroll");
                if (spellbook.Blueprint.AssetGuid.ToString() is "587066af76a74f47a904bb017697ba08")
                {
                    return !spellbook.IsKnown(spell);
                }
                return __result;
            }
        }
    }
}
