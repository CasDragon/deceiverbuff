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
    //public static readonly LogWrapper logger = LogWrapper.Get("deceiverbuff");
    internal static UnityModManager.ModEntry.ModLogger log;
    internal static ModEntry entry;

    public static bool Load(ModEntry modEntry)
    {
        log = modEntry.Logger;
        entry = modEntry;
        modEntry.OnGUI = OnGUI;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        modEntry.OnSaveGUI = OnSaveGUI;
        return true;
    }

    public static void OnGUI(ModEntry modEntry)
    {

    }
    private static void OnSaveGUI(ModEntry modEntry)
    {
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
                    log.Log("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;
                log.Log("Initializing settings");
                Settings.InitializeSettings();
                if (!CheckDLCStatus())
                {
                    log.Log("User doesn't have DLC 6, no patching required");
                    return;
                }
                else
                {
                    log.Log("Patching Deceiver progression.");
                    Progression.Configure();
                    log.Log("Patching Deceiver Merging.");
                    Merging.Configure();
                    log.Log("Patching Deceiver Spell List.");
                    SpellList.Configure();
                }
            }
            catch (Exception e)
            {
                log.Error("Failed to initialize." + e);
            }
        }
    }
}