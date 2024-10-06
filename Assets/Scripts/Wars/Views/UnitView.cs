using System;
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

        private IDisposable _disposable;

        public override async UniTask LoadData(TData data)
        {
            await base.LoadData(data);
            statusBarView.Bind(data);
            _disposable = data.Health.Collect((previous, current, transition) =>
            {
                if (current.current >= 0) return;
                rd.velocity = Vector2.zero;
                cd.enabled = false;
                Destroy(gameObject, 1f);
            });
        }

        public override async UniTask UnloadData()
        {
            _disposable.Dispose();
            statusBarView.Unbind();
            await base.UnloadData();
        }

        #endregion

        #region UnitView

        // ReSharper disable once StaticMemberInGenericType
        private static long sID = 0;
        protected static long GenerateId() => sID++;

        [Space] [SerializeField]
        protected Rigidbody2D rd;
        [SerializeField] protected CircleCollider2D cd;

        [Space] [SerializeField]
        protected VisionView visionView;
        [SerializeField] protected StatusBarView statusBarView;

        // public Unit Unit => Data;

        #endregion
    }
}