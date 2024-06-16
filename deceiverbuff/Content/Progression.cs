using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using deceiverbuff.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deceiverbuff.Content
{
    internal class Progression
    {
        private const string SpellsPerDay = "Deceiver.SpellsPerDay";
        public static void Configure()
        {
            SpellbookConfigurator.For(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetSpellsPerDay(GetSpellSlots())
                .Configure();
        }
        public static BlueprintSpellsTable GetSpellSlots()
        {
            var wizardSpellSlots = SpellsTableRefs.WizardSpellLevels.Reference.Get();
            return SpellsTableConfigurator.New(SpellsPerDay, Guids.DeceiverSpellsPerDayNew)
                .SetLevels(wizardSpellSlots.Levels)
                .Configure();
        }
    }
}
