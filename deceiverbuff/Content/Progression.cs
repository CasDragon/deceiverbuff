using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using deceiverbuff.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Blueprints;

namespace deceiverbuff.Content
{
    internal class Progression
    {
        private const string SpellsPerDay = "Deceiver.SpellsPerDay";
        public static void Configure()
        {
            Main.logger.Info("Starting Progression Configure");
            SpellbookConfigurator.For(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetSpellsPerDay(GetSpellSlots())
                .SetCanCopyScrolls(true)
                .Configure();
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
}
