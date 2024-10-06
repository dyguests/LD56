using UnityEngine;
using Wars.Entities;
using Wars.ScriptableObjects;

namespace Wars.Views
{
    public abstract class BuildingView<TData> : UnitView<TData>
        where TData : Building
    {
        [Space] [SerializeField]
        private CreatureSo[] creatureSos;
        public CreatureSo[] CreatureSos => creatureSos;
    }
}