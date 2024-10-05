using System;
using UnityEngine;

namespace Wars.Entities
{
    [Serializable]
    public abstract class Unit
    {
        // [Header("Precondition")]

        [Header("Cost")]
        [SerializeField]
        private int costFood = 5;

        public int CostFood
        {
            get => costFood;
            set => costFood = value;
        }

        [SerializeField]
        private float costTime = 5f;

        public float CostTime
        {
            get => costTime;
            set => costTime = value;
        }
    }
}