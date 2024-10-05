using System;
using Cysharp.Threading.Tasks;
using Koyou.Commons;
using Scenes.Games.Entities;
using UnityEngine;
using Wars.ScriptableObjects;

namespace Scenes.Games.Views
{
    public abstract class FactionCtlr : MonoBehaviour
    {
        protected FactionBase factionBase;

        [SerializeField] private RaceSo raceSo;
        public RaceSo RaceSo => raceSo;

        protected virtual async UniTask LoadData(int factionIndex, FactionBase factionBase, Transform parent)
        {
            name = $"{factionBase.ctlrType}Ctlr{factionIndex}";
            transform.localPosition = new Vector3(1 + factionIndex * 2, 0, 0);
            this.factionBase = factionBase;

            switch (factionBase.raceType)
            {
                case FactionBase.RaceType.Frog:
                {
                    raceSo = await Resources.LoadAsync<RaceSo>("ScriptableObjects/FrogRaceSo").ToUniTask<RaceSo>();
                    break;
                }
                case FactionBase.RaceType.Spider:
                {
                    raceSo = await Resources.LoadAsync<RaceSo>("ScriptableObjects/SpiderRaceSo").ToUniTask<RaceSo>();
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}