using UnityEngine;

namespace Wars.Views
{
    public abstract class BuildingView : UnitView
    {
        [Space]
        [SerializeField]
        private CreatureView[] creatureSpawns;

        public CreatureView[] CreatureSpawns => creatureSpawns;
    }
}