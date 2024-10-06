using Koyou.Frameworks;
using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public abstract class UnitView<TData> : DataView<TData>
        where TData : Unit
    {
        #region UnitView

        // ReSharper disable once StaticMemberInGenericType
        private static long sID = 0;
        protected static long GenerateId() => sID++;

        [Space] [SerializeField]
        protected CircleCollider2D cd;

        // public Unit Unit => Data;

        #endregion
    }
}