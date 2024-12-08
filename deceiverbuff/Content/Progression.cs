using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using deceiverbuff.Util;
using System;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;
using HarmonyLib;

namespace deceiverbuff.Content
{
    internal class Progression
    {
        private const string SpellsPerDay = "Deceiver.SpellsPerDay";
        public static void Configure()
        {
            Main.logger.Info("Starting Progression Configure");
            SpellbookConfigurator mdbook = SpellbookConfigurator.For(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get());
            if (Settings.GetSetting<bool>("extendslots"))
            {
                mdbook.SetSpellsPerDay(GetSpellSlots());
            }
            if (Settings.GetSetting<bool>("copyscrolls"))
            {
                mdbook.SetCanCopyScrolls(true);
            }
            if (Settings.GetSetting<bool>("useint"))
            {
                mdbook.SetCastingAttribute(StatType.Intelligence);
            }
            else
            {
                mdbook.SetCastingAttribute(StatType.Charisma);
            }
            mdbook.Configure();
            SpellbookRefs.MagicDeceiverSpellbook.Reference.Get().GetComponent<MagicHackSpellbookComponent>().m_MaxDamageDicesPerAction = [5, 7, 10, 15, 20, 50, 50, 50, 50, 50];
            Main.logger.Info("Completed Progression Configure");
        }
        public static BlueprintSpellsTable GetSpellSlots()
        {
            var wizardSpellSlots = SpellsTableRefs.WizardSpellLevels.Reference.Get();
            return SpellsTableConfigurator.New(SpellsPerDay, Guids.DeceiverSpellsPerDayNew)
                .SetLevels(wizardSpellSlots.Levels)
                .Configure();
        }
    }

    [HarmonyPatch(typeof(Spellbook))]
    internal class Spellbook_Deceiver_Patch
    {
        [HarmonyPatch(nameof(Spellbook.GetSpellsPerDay)), HarmonyPostfix]
        public static void GetSpellsPerDay_Patch(ref int __result, Spellbook __instance)
        {
            if (Settings.GetSetting<bool>("extendperday"))
            {
                if (Settings.GetSetting<bool>("cheatyperday"))
                {
                    try
                    {
                        if (__instance.Blueprint.GetComponent<MagicHackSpellbookComponent>() != null)
                        {
                            ModifiableValueAttributeStat modifiableValueAttributeStat = __instance.Owner.Stats.GetStat(__instance.Blueprint.CastingAttribute) as ModifiableValueAttributeStat;
                            __result += modifiableValueAttributeStat.PermanentBonus;
                        }
                    }
                    catch (Exception e)
                    {
                        //Main.logger.Error("Error when patching SpellsPerDay - \n" + e);
                    }
                }
            }
        }
    }
}
