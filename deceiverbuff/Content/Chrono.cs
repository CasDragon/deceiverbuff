using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Abilities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deceiverbuff.Content
{
    internal class Chrono
    {
        public static void Configure()
        {
            
            AbilityConfigurator.For(AbilityRefs.ChronomancyAbility)
                .EditComponent<AbilityEffectRunAction>(c =>
                    c.Actions.Actions
                    .OfType<ContextActionRestoreAllSpellSlots>()
                    .First()
                    .m_UpToSpellLevel = 11)
                .Configure();
        }
    }
}
