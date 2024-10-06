using System;

namespace Wars.Entities
{
    [Serializable] public class Building : Unit
    {
        public Building(BuildingBase buildingBase) : base(buildingBase) { }
    }
}