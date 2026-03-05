using BepInEx;
using BepInEx.Logging;
using EFT;
using HarmonyLib;

namespace DontShootTheBus
{
    [BepInPlugin("com.chazu.dont-shoot-the-bus", "Dont Shoot The Bus", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new Harmony("com.chazu.dont-shoot-the-bus").PatchAll();
            Logger.LogInfo("Dont Shoot The Bus loaded — bots will now ignore the BTR.");
        }
    }

    [HarmonyPatch(typeof(BotsGroup), nameof(BotsGroup.IsPlayerEnemy))]
    public static class BotsGroup_IsPlayerEnemy_Patch
    {
        public static bool Prefix(BotsGroup __instance, IPlayer player, ref bool __result)
        {
            try
            {
                if (__instance.InitialBotType == WildSpawnType.shooterBTR)
                {
                    __result = false;
                    return false;
                }

                if (player.AIData != null && player.AIData.IsAI && player.AIData.BotOwner != null)
                {
                    if (player.AIData.BotOwner.Profile.Info.Settings.Role == WildSpawnType.shooterBTR)
                    {
                        __result = false;
                        return false;
                    }
                }
            }
            catch { }
            return true;
        }
    }

    [HarmonyPatch(typeof(BotsGroup), nameof(BotsGroup.AddEnemy))]
    public static class BotsGroup_AddEnemy_Patch
    {
        public static bool Prefix(BotsGroup __instance, IPlayer person, ref bool __result)
        {
            try
            {
                if (__instance.InitialBotType == WildSpawnType.shooterBTR)
                {
                    __result = false;
                    return false;
                }

                if (person.AIData != null && person.AIData.IsAI && person.AIData.BotOwner != null)
                {
                    if (person.AIData.BotOwner.Profile.Info.Settings.Role == WildSpawnType.shooterBTR)
                    {
                        __result = false;
                        return false;
                    }
                }
            }
            catch { }
            return true;
        }
    }
}
