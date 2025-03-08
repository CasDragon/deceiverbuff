using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using deceiverbuff.Util;

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
        private const string GDIncorporateName = "GD.IncorprateName";
        private const string GDIncorporateDesc = "GD.IncorprateDisc";

        public static void Configure()
        {
            if (Settings.GetSetting<bool>("mergingsettings"))
            {
                Main.log.Log("Starting Merging Configure");
                Main.log.Log("Adding Aeon Incorporate");
                AddAeon();
                Main.log.Log("Adding Angel Incorporate");
                AddAngel();
                Main.log.Log("Adding Azata Incorporate");
                AddAzata();
                Main.log.Log("Adding Demon Incorporate");
                AddDemon();
                Main.log.Log("Adding Lich Incorporate");
                AddLich();
                Main.log.Log("Adding Trickster Incorporate");
                AddTrickster();
                Main.log.Log("Adding GD Incorporate");
                AddGoldDragon();
                Main.log.Log("Completed Merging Configure");
            }
            else
            {
                Main.log.Log("Merging disabled, configuring disabled");
                AddDisabledBooks();
            }
        }
        public static void AddDisabledBooks()
        {
            FeatureSelectMythicSpellbookConfigurator.New(AeonIncorporateName, Guids.AeonSpellbookNew).Configure();
            FeatureSelectMythicSpellbookConfigurator.New(AzataIncorporateName, Guids.AzataSpellbookNew).Configure();
            FeatureSelectMythicSpellbookConfigurator.New(DemonIncorporateName, Guids.DemonSpellbookNew).Configure();
            FeatureSelectMythicSpellbookConfigurator.New(TricksterIncorporateName, Guids.TricksterSpellbookNew).Configure();
            FeatureSelectMythicSpellbookConfigurator.New(GDIncorporateName, Guids.GDSpellbookNew).Configure();
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
            var thing = FeatureSelectMythicSpellbookConfigurator.New(AeonIncorporateName, Guids.AeonSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(AeonIncorporateName)
                .SetDescription(AeonIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellListRefs.AeonSpellMythicList.Reference.Get())
                .Configure();

            ProgressionConfigurator.For(ProgressionRefs.AeonProgression.Reference.Get())
                .AddToLevelEntry(1, thing)
                .Configure();
        }
        public static void AddAzata()
        {
            var thing = FeatureSelectMythicSpellbookConfigurator.New(AzataIncorporateName, Guids.AzataSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(AzataIncorporateName)
                .SetDescription(AzataIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellListRefs.AzataMythicSpellsSpelllist.Reference.Get())
                .Configure();

            ProgressionConfigurator.For(ProgressionRefs.AzataProgression.Reference.Get())
                .AddToLevelEntry(1, thing)
                .Configure();
        }
        public static void AddDemon()
        {
            var thing = FeatureSelectMythicSpellbookConfigurator.New(DemonIncorporateName, Guids.DemonSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(DemonIncorporateName)
                .SetDescription(DemonIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellListRefs.DemonSpelllist.Reference.Get())
                .Configure();

            ProgressionConfigurator.For(ProgressionRefs.DemonProgression.Reference.Get())
                .AddToLevelEntry(1, thing)
                .Configure();
        }
        public static void AddTrickster()
        {
            var thing = FeatureSelectMythicSpellbookConfigurator.New(TricksterIncorporateName, Guids.TricksterSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(TricksterIncorporateName)
                .SetDescription(TricksterIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellListRefs.TricksterSpelllistMythic.Reference.Get())
                .Configure();

            ProgressionConfigurator.For(ProgressionRefs.TricksterProgression.Reference.Get())
                .AddToLevelEntry(1, thing)
                .Configure();
        }
        public static void AddGoldDragon()
        {
            var thing = FeatureSelectMythicSpellbookConfigurator.New(GDIncorporateName, Guids.GDSpellbookNew)
                .AddToAllowedSpellbooks(SpellbookRefs.MagicDeceiverSpellbook.Reference.Get())
                .SetDisplayName(GDIncorporateName)
                .SetDescription(GDIncorporateDesc)
                .SetSpellKnownForSpontaneous(SpellsTableRefs.MythicSpontaneousSpellsKnownTable.Reference.Get())
                .SetMythicSpellList(SpellListRefs.GoldDragonSpellList.Reference.Get())
                .Configure();

            ProgressionConfigurator.For(ProgressionRefs.GoldenDragonProgression.Reference.Get())
                .AddToLevelEntry(1, thing)
                .Configure();
        }
    }
}
