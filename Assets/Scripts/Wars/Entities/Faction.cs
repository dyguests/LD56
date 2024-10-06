using System;
using Koyou.Commons.Entities;
using Koyou.Reactives;
using UnityEngine;

namespace Wars.Entities
{
    /// <summary>
    /// 势力
    ///
    /// 代表 一个玩家/一个电脑
    /// </summary>
    [Serializable]
    public class Faction
    {
        [SerializeField] private LimitInt food = new(100, 9999);

        public Reactive<LimitInt> Food=> food;

        [SerializeField] private LimitInt population = new(0, 999);

        public LimitInt Population
        {
            get => population;
            set => population = value;
        }
    }
}