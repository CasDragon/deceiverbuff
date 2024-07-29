using HarmonyLib;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.UnitLogic;
using Kingmaker.PubSubSystem;
using Kingmaker.Blueprints.Classes.Spells;

namespace deceiverbuff.Content
{
    internal class Fixes
    {
        public static void Configure()
        {

        }

        [HarmonyPatch(typeof(DraconicBloodlineArcana))]
        internal class DraconicBloodline_Patch
        {
            [HarmonyPatch(nameof(DraconicBloodlineArcana.OnEventAboutToTrigger)), HarmonyPrefix]
            public static void OnEventAboutToTrigger_Patch(RuleCalculateDamage evt, DraconicBloodlineArcana __instance)
            {
                MechanicsContext context = evt.Reason.Context;
                Main.logger.Info("Checking Draconic Bloodline Arcana - Deceiver Buff Prefix");
                if (((context != null) ? context.SourceAbility : null) == null)
                {
                    Main.logger.Info("Context is null for Magical Deceiver and Dragonic Bloodline");
                    return;
                }
                if (!context.SpellDescriptor.HasAnyFlag(__instance.SpellDescriptor))
                {
                    Main.logger.Info("Merged spell is missing descriptor");
                    return;
                }
                if  (!context.SourceAbility.IsSpell && __instance.SpellsOnly)
                {
                    Main.logger.Info("Merged spell isn't considered a spell");
                    Main.logger.Info(context.SourceAbility.IsSpell.ToString());
                    return;
                }
                if (context.SourceAbility.Type == AbilityType.Physical)
                {
                    Main.logger.Info("Merged spell is considered a physical ability");
                    return;
                }
            }
        }
    }
}
