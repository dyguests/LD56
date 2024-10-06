using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public abstract class BuildingView<TData> : UnitView<TData>
        where TData : Building
    {
        [Space] [SerializeField]
        private Creature[] creatureSpawns;

        public Creature[] CreatureSpawns => creatureSpawns;
    }
}