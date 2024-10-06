using Koyou.Frameworks;
using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public abstract class UnitView<TData> : DataView<TData>
        where TData : Unit
    {
        #region UnitView

        [SerializeField] protected CircleCollider2D cd;

        // public Unit Unit => Data;

        #endregion
    }
}