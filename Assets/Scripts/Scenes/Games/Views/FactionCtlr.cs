using System;
using Cysharp.Threading.Tasks;
using Koyou.Commons;
using Scenes.Games.Entities;
using UnityEngine;
using Wars.Entities;
using Wars.ScriptableObjects;
using Wars.Views;

namespace Scenes.Games.Views
{
    public abstract class FactionCtlr : MonoBehaviour
    {
        protected FactionBase factionBase;

        protected Faction faction;
        public Faction Faction => faction;

        [SerializeField] private RaceSo raceSo;
        public RaceSo RaceSo => raceSo;

        [Header("主基地")] [SerializeField]
        private MainbaseView mainbaseView;
        public MainbaseView MainbaseView => mainbaseView;

        protected virtual async UniTask LoadData(int factionIndex, FactionBase factionBase, Transform parent)
        {
            name = $"{factionBase.ctlrType}Ctlr{factionIndex}";
            transform.localPosition = new Vector3(1 + factionIndex * 2, 0, 0);
            this.factionBase = factionBase;
            faction = new Faction();

            switch (factionBase.raceType)
            {
                case FactionBase.RaceType.Frog:
                {
                    raceSo = await Resources.LoadAsync<RaceSo>("ScriptableObjects/Races/Frogs/FrogRaceSo").ToUniTask<RaceSo>();
                    break;
                }
                case FactionBase.RaceType.Spider:
                {
                    raceSo = await Resources.LoadAsync<RaceSo>("ScriptableObjects/Races/Spiders/SpiderRaceSo").ToUniTask<RaceSo>();
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region GenerateMainBaseView

        /// <summary>
        /// 这个实例中，此方法仅去被调用一次
        /// </summary>
        /// <param name="spawnPoint"></param>
        /// <returns></returns>
        public MainbaseView GenerateMainBaseView(SpawnPoint spawnPoint)
        {
            var instance = RaceSo.prefab.Duplicate(faction, spawnPoint.transform.position, true);
            spawnPoint.MainbaseView = mainbaseView = instance;
            return instance;
        }

        #endregion
    }
}