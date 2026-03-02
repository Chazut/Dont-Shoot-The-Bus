using BepInEx;
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

    [HarmonyPatch(typeof(BotsGroup), nameof(BotsGroup.AddEnemy))]
    public static class BotsGroup_AddEnemy_Patch
    {
        public static bool Prefix(IPlayer person)
        {
            if (BTRControllerClass.Instance?.BotShooterBtr != null &&
                person.Id == BTRControllerClass.Instance.BotShooterBtr.GetPlayer.Id)
            {
                return false;
            }
            return true;
        }
    }
}
