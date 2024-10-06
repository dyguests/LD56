using System;

namespace Wars.Entities
{
    [Serializable]
    public abstract class UnitBase
    {
        public int costFood = 25;
        public int costPopulation = 1;
        public float costTime = 5;

        public int health = 50;
        public int attack = 5;
        public float attackSpeed = 1;
    }
}