using System;

namespace Wars.Entities
{
    [Serializable] public class Building : Unit
    {
        public Building(BuildingBase unitBase) : base(unitBase) { }
    }
}