using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deceiverbuff.Content
{
    internal class SpellList
    {
        public static void Configure()
        {
            Main.logger.Info("Starting Spelllist Configure");
            // todo
            // Hellfire Ray, Magic Missle, cantrips, Energy Drain, Ill Omen, Polar Ray, Wave of Exhaustion, Wave of Fatigue, Tidal Wave, Black Tentacles, Infernal Healing
            AddHellFire();
            Main.logger.Info("Completed Spelllist Configure");
        }
        public static void AddHellFire()
        {
            Main.logger.Verbose("Adding Hellfire Ray To Deceiver");
            AbilityConfigurator.For(AbilityRefs.HellfireRay.Reference.Get())
                .AddToSpellList(level: 6, SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .Configure();
        }
    }
}
