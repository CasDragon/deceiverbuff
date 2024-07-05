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

namespace deceiverbuff;

#if DEBUG
[EnableReloading]
#endif
public static class Main
{
    internal static Harmony HarmonyInstance;
    public static readonly LogWrapper logger = LogWrapper.Get("deceiverbuff");

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
#if DEBUG
        modEntry.OnUnload = OnUnload;
#endif
        modEntry.OnGUI = OnGUI;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

        return true;
    }

    public static void OnGUI(UnityModManager.ModEntry modEntry)
    {

    }

#if DEBUG
    public static bool OnUnload(UnityModManager.ModEntry modEntry)
    {
        HarmonyInstance.UnpatchAll(modEntry.Info.Id);
        return true;
    }
    public static bool CheckDLCStatus()
    {
        // Check if user owns DLC 6
        return DlcRefs.Dlc6.Reference.Get().IsAvailable;
    }
#endif
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