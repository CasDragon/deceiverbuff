using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.References;
using deceiverbuff.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deceiverbuff.Content
{
    internal class Merging
    {
        private const string AeonIncorporateName = "Aeon.IncorprateName";
        private const string AeonIncorporateDesc = "Aeon.IncorprateDisc";
        private const string AzataIncorporateName = "Azata.IncorprateName";
        private const string AzataIncorporateDesc = "Azata.IncorprateDisc";
        private const string DemonIncorporateName = "Demon.IncorprateName";
        private const string DemonIncorporateDesc = "Demon.IncorprateDisc";
        private const string TricksterIncorporateName = "Trickster.IncorprateName";
        private const string TricksterIncorporateDesc = "Trickster.IncorprateDisc";

        public static void Configure()
        {
            Main.logger.Info("Starting Merging Configure");
            Main.logger.Verbose("Adding Aeon Incorporate");
            AddAeon();
            Main.logger.Verbose("Adding Angel Incorporate");
            AddAngel();
            Main.logger.Verbose("Adding Azata Incorporate");
            AddAzata();
            Main.logger.Verbose("Adding Demon Incorporate");
            AddDemon();
            Main.logger.Verbose("Adding Lich Incorporate");
            AddLich();
            Main.logger.Verbose("Adding Trickster Incorporate");
            AddTrickster();
            Main.logger.Info("Completed Merging Configure");
        }
        public static void AddAngel()
        {
            FeatureSelectMythicSpellbookConfigurator.For(FeatureSelectMythicSpellbookRefs.AngelIncorporateSpellbook)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .Configure();
        }
        public static void AddLich()
        {
            FeatureSelectMythicSpellbookConfigurator.For(FeatureSelectMythicSpellbookRefs.LichIncorporateSpellbookFeature)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .Configure();
        }
        public static void AddAeon()
        {
            FeatureSelectMythicSpellbookConfigurator.New(AeonIncorporateName, Guids.AeonSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(AeonIncorporateName)
                .SetDescription(AeonIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellsTableRefs.AeonSpellKnownTable.Reference.Get())
                .Configure();
        }
        public static void AddAzata()
        {
            FeatureSelectMythicSpellbookConfigurator.New(AzataIncorporateName, Guids.AzataSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(AzataIncorporateName)
                .SetDescription(AzataIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellsTableRefs.AzataSpellKnownTable.Reference.Get())
                .Configure();
        }
        public static void AddDemon()
        {
            FeatureSelectMythicSpellbookConfigurator.New(DemonIncorporateName, Guids.DemonSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(DemonIncorporateName)
                .SetDescription(DemonIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellsTableRefs.DemonSpellKnownTable.Reference.Get())
                .Configure();
        }
        public static void AddTrickster()
        {
            FeatureSelectMythicSpellbookConfigurator.New(TricksterIncorporateName, Guids.TricksterSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(TricksterIncorporateName)
                .SetDescription(TricksterIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellsTableRefs.TricksterSpellKnownTable.Reference.Get())
                .Configure();
        }
    }
}
