using HarmonyLib;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.RuleSystem.Rules.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deceiverbuff.Content
{
    internal class ComponentFixes
    {
        /*[HarmonyPatch(typeof(IncreaseAllSpellsDC))]
        internal class IncreaseAllSpellsDC_Patch()
        {
            [HarmonyPatch(nameof(IncreaseAllSpellsDC.OnEventAboutToTrigger))]
            [HarmonyPostfix]
            public static void OnEventAboutToTrigger_Patch(RuleCalculateAbilityParams evt, IncreaseAllSpellsDC __instance)
            {
                Main.log.Log("Debugging IncreaseAllSpellsDC - start");
                Main.log.Log($"Event's spellbook is - {evt.Spellbook.ToString()}");
                Main.log.Log($"SpellsOnly value - {__instance.SpellsOnly.ToString()}");
                if (__instance.SpellsOnly && evt.Spellbook == null)
                    Main.log.Log("Event doesn't qualify for DC bonus");
                else
                    Main.log.Log("Event DOES qualify for DC bonus");
                Main.log.Log("Debugging IncreaseAllSpellsDC - end");
            }
        }*/
    }
}
