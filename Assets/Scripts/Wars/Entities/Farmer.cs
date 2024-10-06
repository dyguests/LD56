using System;

namespace Wars.Entities
{
    [Serializable]
    public class Farmer : Creature
    {
        public static Farmer CreateFrom(FarmerBase farmerBase) => new(farmerBase);

        private Farmer(FarmerBase farmerBase) : base(farmerBase) { }
    }
}