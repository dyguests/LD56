using System;
using Koyou.Commons.Entities;
using Koyou.Reactives;
using UnityEngine;

namespace Wars.Entities
{
    [Serializable]
    public abstract class Unit
    {
        // [Header("Precondition")]

        [Header("Cost")] [SerializeField]
        private int costFood = 5;

        public int CostFood
        {
            get => costFood;
            set => costFood = value;
        }

        [SerializeField] private int costPopulation = 1;

        public int CostPopulation
        {
            get => costPopulation;
            set => costPopulation = value;
        }

        [SerializeField] private float costTime = 5f;

        public float CostTime
        {
            get => costTime;
            set => costTime = value;
        }

        [SerializeField] private LimitInt health;
        private Reactive<LimitInt> _healthReactive;
        public Reactive<LimitInt> Health => _healthReactive ??= Reactive.Delegate(() => health, v => health = v);
        [SerializeField] private int attack;
        private Reactive<int> _attackReactive;
        public Reactive<int> Attack => _attackReactive ??= Reactive.Delegate(() => attack, v => attack = v);
        [SerializeField] private float attackSpeed;
        private Reactive<float> _attackSpeedReactive;
        public Reactive<float> AttackSpeed => _attackSpeedReactive ??= Reactive.Delegate(() => attackSpeed, v => attackSpeed = v);
        private float _speed;
        private Reactive<float> _speedReactive;
        public Reactive<float> Speed => _speedReactive ??= Reactive.Delegate(() => _speed, v => _speed = v);


        protected Unit(UnitBase unitBase)
        {
            costFood = unitBase.costFood;
            costPopulation = unitBase.costPopulation;
            costTime = unitBase.costTime;

            health = unitBase.health;
            attack = unitBase.attack;
            attackSpeed = unitBase.attackSpeed;
            _speed = unitBase.speed;
        }
    }
}