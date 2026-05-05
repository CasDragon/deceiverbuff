using System;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using deceiverbuff.Util;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;
using static Kingmaker.GameModes.GameModeType;

namespace deceiverbuff.Content
{
    internal class Progression
    {
        private const string SpellsPerDay = "Deceiver.SpellsPerDay";
        public static void Configure()
        {
            Main.log.Log("Starting Progression Configure");
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
            SpellbookRefs.MagicDeceiverSpellbook.Reference.Get().GetComponent<MagicHackSpellbookComponent>().m_MaxDamageDicesPerAction = [5, 7, 10, 15, 20, 100, 100, 100, 100, 100];
            Main.log.Log("Completed Progression Configure");
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
        public static void GetSpellsPerDay_Patch(ref int __result, Spellbook __instance, int spellLevel)
        {
            if (Settings.GetSetting<bool>("extendperday"))
            {
                if (Settings.GetSetting<bool>("supercheatyperday"))
                {
                    try
                    {
                        if (__instance.Blueprint.GetComponent<MagicHackSpellbookComponent>() != null)
                        {
                            ModifiableValueAttributeStat modifiableValueAttributeStat = __instance.Owner.Stats.GetStat(__instance.Blueprint.CastingAttribute) as ModifiableValueAttributeStat;
                            __result += modifiableValueAttributeStat.BonusWithoutTemp;
                        }
                    }
                    catch (Exception e)
                    {
                        //Main.log.Error("Error when patching SpellsPerDay - \n" + e);
                    }
                }
                else if (Settings.GetSetting<bool>("cheatyperday"))
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
                        //Main.log.Error("Error when patching SpellsPerDay - \n" + e);
                    }
                }
                else
                {
                    try
                    {
                        if (__instance.Blueprint.GetComponent<MagicHackSpellbookComponent>() != null)
                        {
                            ModifiableValueAttributeStat modifiableValueAttributeStat = __instance.Owner.Stats.GetStat(__instance.Blueprint.CastingAttribute) as ModifiableValueAttributeStat;
                            int num = 0;
                            int num2 = (__instance.Owner.IsPlayerFaction ? ((modifiableValueAttributeStat.CalculatePermanentValueWithoutTempBuffs() - 10) / 2 - spellLevel) : ((modifiableValueAttributeStat.BaseValue - 10) / 2 - spellLevel));
                            if (num2 >= 0 && spellLevel > 0)
                            {
                                int num3 = num2 / 4 + 1;
                                num += num3;
                            }
                            __result += num; 
                        }
                    }
                    catch (Exception e)
                    {
                        //Main.log.Error("Error when patching SpellsPerDay - \n" + e);
                    }
                }
            }
        }
    }
}
