using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
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
            // cantrips, Black Tentacles, Infernal Healing, False life/Greater, Heroism/Greater, Magic weapoo/greater
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
            AddToList(8, AbilityRefs.AngelicAspectGreater.Reference.Get());
            Main.logger.Info("Completed Spelllist Configure");
        }
        public static void  AddToList(int level, BlueprintAbility spell)
        {
            Main.logger.Verbose("Adding" + spell.NameSafe() + "to Deceiver");
            AbilityConfigurator.For(spell)
                .AddToSpellList(level, SpellListRefs.MagicDeceiverSpellList.Reference.Get())
                .Configure();
        }
    }
}
