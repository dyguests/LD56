using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public abstract class UnitView<TData> : DataView<TData>
        where TData : Unit
    {
        #region DataView<TData>

        public override async UniTask LoadData(TData data)
        {
            await base.LoadData(data);
            statusBarView.Bind(data);
        }

        public override async UniTask UnloadData()
        {
            statusBarView.Unbind();
            await base.UnloadData();
        }

        #endregion

        #region UnitView

        // ReSharper disable once StaticMemberInGenericType
        private static long sID = 0;
        protected static long GenerateId() => sID++;

        [Space] [SerializeField]
        protected CircleCollider2D cd;

        [Space] [SerializeField]
        protected StatusBarView statusBarView;

        // public Unit Unit => Data;

        #endregion
    }
}