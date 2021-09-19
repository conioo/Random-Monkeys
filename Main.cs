using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Models;
using BTD_Mod_Helper;
using MelonLoader;
using HarmonyLib;

namespace RandomMonkeys
{
    class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("Mod Random Monkeys Loaded!");
        }

        [HarmonyPatch(typeof(Tower), "Initialise")]
        public class TowerInitialise_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(Tower __instance, ref Model modelToUse)
            { 
                
                if (modelToUse.name.Contains("Tier"))
                {

                    if (modelToUse.name.Contains("Tier_0"))
                    {
                        modelToUse = RandomMonkeys.GetTowerModelTier0();
                    }
                    else if (modelToUse.name.Contains("Tier_1"))
                    {
                        modelToUse = RandomMonkeys.GetTowerModel(1);
                    }
                    else if (modelToUse.name.Contains("Tier_2"))
                    {
                        modelToUse = RandomMonkeys.GetTowerModel(2);
                    }
                    else if (modelToUse.name.Contains("Tier_3"))
                    {
                        modelToUse = RandomMonkeys.GetTowerModel(3);
                    }
                    else if (modelToUse.name.Contains("Tier_4"))
                    {
                        modelToUse = RandomMonkeys.GetTowerModel(4);
                    }
                    else if (modelToUse.name.Contains("Tier_5"))
                    {
                        modelToUse = RandomMonkeys.GetTowerModel(5);
                    }
                    else
                    {
                        modelToUse = RandomMonkeys.GetTowerModelAny();
                    }

                }

                return true;
            }
        }
    }
}
