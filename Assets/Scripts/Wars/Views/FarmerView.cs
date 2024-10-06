using Cysharp.Threading.Tasks;
using Koyou.Commons;
using Scenes.Games.Views;
using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public class FarmerView : CreatureView<Farmer>
    {
        #region DataView<TData>

        private Heartbeat _heartbeat;

        public override async UniTask LoadData(Farmer data)
        {
            await base.LoadData(data);
            _heartbeat = Heartbeat.Run(HeartbeatProcess);
        }


        public override async UniTask UnloadData()
        {
            _heartbeat.Stop();
            await base.UnloadData();
        }

        #endregion

        #region FarmerView

        public FactionCtlr Opponent { get; set; }

        public FarmerView Duplicate(Vector3 position)
        {
            var instance = Instantiate(this, position, Quaternion.identity);
            instance.name = $"Farmer{GenerateId()}";
            return instance;
        }

        private async UniTask HeartbeatProcess()
        {
            rd.velocity = Data.Speed * (Opponent.MainbaseView.transform.position - transform.position).normalized;
        }

        #endregion
    }
}