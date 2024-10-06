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
        [SerializeField] private LimitInt food = new(9999, 9999);
        private Reactive<LimitInt> _foodReactive;
        public Reactive<LimitInt> Food => _foodReactive ??= Reactive.Delegate(() => food, v => food = v);

        [SerializeField] private LimitInt population = new(0, 999);
        private Reactive<LimitInt> _populationReactive;
        public Reactive<LimitInt> Population => _populationReactive ??= Reactive.Delegate(() => population, v => population = v);
    }
}