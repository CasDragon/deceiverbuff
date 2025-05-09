﻿using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using HarmonyLib;
using Kingmaker.UnitLogic;
using deceiverbuff.Util;

namespace deceiverbuff.Content
{
    internal class SpellList
    {
        public static void Configure()
        {
            Main.log.Log("Starting Spelllist Configure");
            // todo
            // Black Tentacles, Infernal Healing
            if (Settings.GetSetting<bool>("addnewspells"))
            {
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
                AddToList(0, AbilityRefs.Ignition.Reference.Get());
                AddToList(7, AbilityRefs.FormOfTheDragonIIGold.Reference.Get());
                AddToList(7, AbilityRefs.FormOfTheDragonIIRed.Reference.Get());
                AddToList(8, AbilityRefs.FormOfTheDragonIIIGold.Reference.Get());
                AddToList(8, AbilityRefs.FormOfTheDragonIIIRed.Reference.Get());
            }
            Main.log.Log("Completed Spelllist Configure");
        }
        public static void  AddToList(int level, BlueprintAbility spell)
        {
            Main.log.Log("Adding" + spell.NameSafe() + "to Deceiver");
            AbilityConfigurator.For(spell)
                .AddToSpellList(level, SpellListRefs.MagicDeceiverSpellList.Reference.Get())
                .Configure();
        }

        [HarmonyPatch(typeof(CopyScroll))]
        static class CopyScroll_Patch
        {
            [HarmonyPatch(nameof(CopyScroll.CanCopySpell)), HarmonyPostfix]
            static void DeceiverScollPatch(ref bool __result, BlueprintAbility spell, Spellbook spellbook)
            {
                if (Settings.GetSetting<bool>("copyscrolls"))
                {
                    try
                    {
                        //Main.log.Log("Patching CanCopyScroll");
                        if (spellbook.Blueprint.AssetGuid == "587066af76a74f47a904bb017697ba08")
                        {
                            __result = !spellbook.IsKnown(spell);
                        }
                    }
                    catch (Exception e)
                    {
                        //Main.log.Error("Error while patching CanCopyScroll -\n " + e);
                    }
                }
            }
        }
        [HarmonyPatch(typeof(BlueprintSpellList))]
        static class LearningScroll_Patch
        {
            [HarmonyPatch(nameof(BlueprintSpellList.GetLevel)), HarmonyPostfix]
            static void DeceiverLearnScroll_Patch(ref int __result, BlueprintSpellList __instance, BlueprintAbility spell)
            {
                if (Settings.GetSetting<bool>("copyscrolls"))
                {
                    try
                    {
                        if (__result == -1)
                        {
                            __result = spell.GetComponent<SpellListComponent>().SpellLevel;
                        }
                    }
                    catch (Exception e)
                    {
                        //Main.log.Error("Error while patching GetLevel -\n" + e);
                    }
                }
            }
        }
    }
}
