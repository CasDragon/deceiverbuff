using Kingmaker.Localization;
using Kingmaker.PubSubSystem;
using Kingmaker.UI.BookEvent;
using ModMenu;
using ModMenu.NewTypes;
using ModMenu.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;

namespace deceiverbuff.Util
{
    internal class Settings
    {
        private static readonly string RootKey = "deceiverbuff";

        public static void InitializeSettings()
        {
            ModMenu.ModMenu.AddSettings(
                SettingsBuilder.New(RootKey, CreateString(GetKey("title"), "Deceiver Buff"))
                    .SetMod(Main.entry)
                    .AddAnotherSettingsGroup(GetKey("spellbookheader"), CreateString(GetKey("spellbooktitle"),"Spell Book Settings"))
                    .AddToggle(
                        Toggle.New(GetKey("mergingsettings"), defaultValue: true, CreateString("mergingSettings-toggle", "Allow you to merge Mythic spellbooks into Magical Deceiver")))
                    .AddToggle(
                        Toggle.New(GetKey("extendslots"), defaultValue: true, CreateString("extendSlots-toggle", "Change the Deceiver casting progression to Wizard progression, allowing for up to level 9/10 spells")))
                    .AddToggle(
                        Toggle.New(GetKey("copyscrolls"), defaultValue: true, CreateString("copyScrolls-toggle", "Allow you to copy spell scrolls into the Deceiver spell book")))
                    .AddToggle(
                        Toggle.New(GetKey("useint"), defaultValue: false, CreateString("useInt-toggle", "Changes the Deceiver spellbook from CHA to INT")))
                    .AddToggle(
                        Toggle.New(GetKey("extendperday"), defaultValue: true, CreateString("extendPerDay-toggle", "Extend the number of casts Deceiver gets per day (currently needs cheaty per day enabled as well)")))
                    .AddToggle(
                        Toggle.New(GetKey("cheatyperday"), defaultValue: true, CreateString("cheatyPerDay-toggle", "Use your full CHA (or INT with setting on) bonus to casts per day")))
                    .AddAnotherSettingsGroup(GetKey("spelllistheader"), CreateString(GetKey("spelllisttitle"),"Spell List Settings"))
                    .AddToggle(
                        Toggle.New(GetKey("addnewspells"), defaultValue: true, CreateString("addNewSpells-toggle", "Add new spells (from the README) to the Deceiver spell list")))
                    .AddAnotherSettingsGroup(GetKey("metamagicHeader"), CreateString(GetKey("metamagictitle"),"Metamagic Settings"))
                    .AddToggle(
                        Toggle.New(GetKey("rodmetamagic"), defaultValue: true, CreateString("rodMetaMagic-toggle", "Allow you to use Metamagic rods with Deceiver merged spells"))));                        
        }
        public static T GetSetting<T>(string key)
        {
            try
            {
                return ModMenu.ModMenu.GetSettingValue<T>(GetKey(key));
            }
            catch (Exception ex)
            {
                Main.log.Error(ex.ToString());
                return default(T);
            }
        }
        private static LocalizedString CreateString(string partialkey, string text)
        {
            return Helpers.CreateString(GetKey(partialkey), text);
        }
        private static string GetKey(string partialKey)
        {
            return $"{RootKey}.{partialKey}";
        }

    }
    public static class Helpers
    {
        private static Dictionary<string, LocalizedString> textToLocalizedString = new Dictionary<string, LocalizedString>();
        public static LocalizedString CreateString(string key, string value)
        {
            // See if we used the text previously.
            // (It's common for many features to use the same localized text.
            // In that case, we reuse the old entry instead of making a new one.)
            if (textToLocalizedString.TryGetValue(value, out LocalizedString localized))
            {
                return localized;
            }
            var strings = LocalizationManager.CurrentPack?.m_Strings;
            if (strings!.TryGetValue(key, out var oldValue) && value != oldValue.Text)
            {
                Main.log.Log($"Info: duplicate localized string `{key}`, different text.");
            }
            var sE = new Kingmaker.Localization.LocalizationPack.StringEntry();
            sE.Text = value;
            strings[key] = sE;
            localized = new LocalizedString
            {
                m_Key = key
            };
            textToLocalizedString[value] = localized;
            return localized;
        }
    }
    /*public class Settings : UnityModManager.ModSettings
    {
        public bool mergingSettings = true;
        public bool extendSlots = true;
        public bool copyScrolls = true;
        public bool useInt = false;
        public bool extendPerDay = true;
        public bool cheatyPerDay = true;
        public bool addNewSpells = true;
        public bool rodMetaMagic = true;
        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }
    }*/
}
