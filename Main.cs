using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Models;
using Il2CppSystem.Collections.Generic;
using BTD_Mod_Helper;
using MelonLoader;
using HarmonyLib;

namespace RandomMonkeys
{
    class Main : BloonsTD6Mod
    {
        public override string GithubReleaseURL => "https://api.github.com/repos/GMConio/Random-Monkeys/releases";

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

        [HarmonyPatch(typeof(TowerInventory), "Init")]
        public class TowerInventory_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(ref List<TowerDetailsModel> allTowersInTheGame)
            {
                if(allTowersInTheGame[31].towerId == "BananaFarm")
                {
                    var supportMonkeys = allTowersInTheGame.GetRange(31, 11);
                    allTowersInTheGame.RemoveRange(31, 11);

                    allTowersInTheGame.Add(supportMonkeys[9]);
                    allTowersInTheGame.Add(supportMonkeys[10]);
                    allTowersInTheGame.Add(supportMonkeys[6]);
                    allTowersInTheGame.Add(supportMonkeys[8]);
                    allTowersInTheGame.Add(supportMonkeys[7]);
                    allTowersInTheGame.Add(supportMonkeys[5]);
                    allTowersInTheGame.Add(supportMonkeys[4]);

                    allTowersInTheGame.Add(supportMonkeys[0]);
                    allTowersInTheGame.Add(supportMonkeys[1]);
                    allTowersInTheGame.Add(supportMonkeys[2]);
                    allTowersInTheGame.Add(supportMonkeys[3]);
                }
                return true;
            }
        }
    }
}
