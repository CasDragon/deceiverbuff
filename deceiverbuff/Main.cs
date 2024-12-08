using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnityModManagerNet;
using deceiverbuff.Content;
using Kingmaker.PubSubSystem;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.JsonSystem;
using BlueprintCore.Blueprints.References;
using static UnityModManagerNet.UnityModManager;
using deceiverbuff.Util;
using UnityEngine;

namespace deceiverbuff;

#if DEBUG
[EnableReloading]
#endif
public static class Main
{
    internal static Harmony HarmonyInstance;
    public static readonly LogWrapper logger = LogWrapper.Get("deceiverbuff");
    internal static ModEntry entry;
    //public static Settings settings;

    public static bool Load(ModEntry modEntry)
    {
#if DEBUG
        modEntry.OnUnload = OnUnload;
#endif
        entry = modEntry;
        modEntry.OnGUI = OnGUI;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        //settings = Settings.Load<Settings>(modEntry);
        modEntry.OnSaveGUI = OnSaveGUI;
        return true;
    }

    public static void OnGUI(ModEntry modEntry)
    {
        GUILayout.Label("Allow Deceiver to merge spell books with all Mythic classes");
        //GUILayout.Toggle(true, GUIContent.)
    }
    private static void OnSaveGUI(ModEntry modEntry)
    {
        //settings.Save(modEntry);
    }
    public static bool CheckDLCStatus()
    {
        // Check if user owns DLC 6
        return true; //DlcRefs.Dlc6.Reference.Get().IsAvailable;
    }
    [HarmonyPatch(typeof(BlueprintsCache))]
    static class BlueprintsCaches_Patch
    {
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        static void Postfix()
        {
            try
            {
                if (Initialized)
                {
                    logger.Info("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;
                logger.Info("Initializing settings");
                Settings.InitializeSettings();
                if (!CheckDLCStatus())
                {
                    logger.Info("User doesn't have DLC 6, no patching required");
                    return;
                }
                else
                {
                    logger.Info("Patching Deceiver progression.");
                    Progression.Configure();
                    logger.Info("Patching Deceiver Merging.");
                    Merging.Configure();
                    logger.Info("Patching Deceiver Spell List.");
                    SpellList.Configure();
                }
            }
            catch (Exception e)
            {
                logger.Error("Failed to initialize." + e);
            }
        }
    }
}