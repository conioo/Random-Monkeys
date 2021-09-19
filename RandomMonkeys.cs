using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using System.Collections.Generic;
using System;

namespace RandomMonkeys
{
    static internal class RandomMonkeys
    {
        private enum Path
        {
            Top,
            Middle,
            Bottom
        }

        static private readonly int[] Converter = new int[] { 0, 1, 2, 2, 3, 3, 3, 4, 4, 5 };

        static public readonly List<string> AllMonkeys = new List<string>
        {
            TowerType.DartMonkey,
            TowerType.BombShooter,
            TowerType.BoomerangMonkey,
            TowerType.IceMonkey,
            TowerType.TackShooter,
            TowerType.GlueGunner,
            TowerType.DartlingGunner,
            TowerType.MonkeyAce,
            TowerType.SniperMonkey,
            TowerType.MonkeySub,
            TowerType.MortarMonkey,
            TowerType.MonkeyBuccaneer,
            TowerType.HeliPilot,
            TowerType.NinjaMonkey,
            TowerType.Alchemist,
            TowerType.SuperMonkey,
            TowerType.WizardMonkey,
            TowerType.Druid,
            TowerType.MonkeyVillage,
            TowerType.EngineerMonkey,
            TowerType.BananaFarm,
            TowerType.SpikeFactory
        };

        static private Random RandomGenerator = new Random();

        static private string GetMonkey() 
        {
            return AllMonkeys[RandomGenerator.Next(22)];
        }

        static internal TowerModel GetTowerModel(int _tier)
        {
            string towerType = RandomMonkeys.GetMonkey();

            int mainPath = RandomGenerator.Next(3);
            int sidePath = RandomGenerator.Next(2);

            int tierSidePath;

            if (_tier != 1)
            {
                tierSidePath = RandomGenerator.Next(3);
            }
            else
            {
                tierSidePath = RandomGenerator.Next(2);
            }


            if (mainPath == 0)
            {
                if(sidePath == 0)
                {
                    return Game.instance.model.GetTower(towerType, _tier, tierSidePath, 0);
                }
                else
                {
                    return Game.instance.model.GetTower(towerType, _tier, 0, tierSidePath);
                }
            }
            else if(mainPath == 1)
            {
                if (sidePath == 0)
                {
                    return Game.instance.model.GetTower(towerType, tierSidePath, _tier, 0);
                }
                else
                {
                    return Game.instance.model.GetTower(towerType, 0, _tier, tierSidePath);
                }
            }
            else
            {
                if (sidePath == 0)
                {
                    return Game.instance.model.GetTower(towerType, tierSidePath, 0, _tier);
                }
                else
                {
                    return Game.instance.model.GetTower(towerType, 0, tierSidePath, _tier);
                }
            }

        }       

        static internal TowerModel GetTowerModelTier0()
        {
            return Game.instance.model.GetTower(RandomMonkeys.GetMonkey(), 0, 0, 0);
        }

        static internal TowerModel GetTowerModelAny()
        {
            return GetTowerModel(Converter[RandomGenerator.Next(10)]);
        }
    }
}
