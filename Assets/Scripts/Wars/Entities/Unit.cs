using System;
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

        [SerializeField] private int health;
        private Reactive<int> _healthReactive;
        public Reactive<int> Health => _healthReactive ??= Reactive.Delegate(() => health, v => health = v);
        [SerializeField] private int attack;
        private Reactive<int> _attackReactive;
        public Reactive<int> Attack => _attackReactive ??= Reactive.Delegate(() => attack, v => attack = v);
        [SerializeField] private float speed;
        private Reactive<float> _speedReactive;
        public Reactive<float> Speed => _speedReactive ??= Reactive.Delegate(() => speed, v => speed = v);


        protected Unit(UnitBase unitBase)
        {
            costFood = unitBase.costFood;
            costPopulation = unitBase.costPopulation;
            costTime = unitBase.costTime;

            health = unitBase.health;
            attack = unitBase.attack;
            speed = unitBase.attackSpeed;
        }
    }
}