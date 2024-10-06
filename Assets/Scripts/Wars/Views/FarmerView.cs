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
            visionView.onVisionEnter = OnVisionEnter;
            visionView.onVisionExit = OnVisionExit;

            _heartbeat = Heartbeat.Run(HeartbeatProcess);
        }

        public override async UniTask UnloadData()
        {
            _heartbeat.Stop();
            await base.UnloadData();
        }

        #endregion

        #region FarmerView

        public FactionCtlr FactionCtlr { get; set; }
        public FactionCtlr Opponent { get; set; }

        public FarmerView Duplicate(Vector3 position)
        {
            var instance = Instantiate(this, position, Quaternion.identity);
            instance.name = $"Farmer{GenerateId()}";
            return instance;
        }

        private async UniTask HeartbeatProcess()
        {
            if (_targetMainbase != null)
            {
                rd.velocity = Data.Speed * (_targetMainbase.transform.position - transform.position).normalized;
                _targetMainbase.Data.Health.Value -= Data.Attack;
                return;
            }
            if (_targetFarmer != null)
            {
                rd.velocity = Data.Speed * (_targetFarmer.transform.position - transform.position).normalized;
                _targetFarmer.Data.Health.Value -= Data.Attack;
                return;
            }

            rd.velocity = Data.Speed * (Opponent.MainbaseView.transform.position - transform.position).normalized;
        }

        #region OnVision

        private MainbaseView _targetMainbase;
        private FarmerView _targetFarmer;

        private void OnVisionEnter(Collider2D other)
        {
            if (other.CompareTag("Mainbase"))
            {
                var mainbaseView = other.GetComponent<MainbaseView>();
                if (FactionCtlr == mainbaseView.FactionCtlr) return;
                _targetMainbase = mainbaseView;
                return;
            }
            if (other.CompareTag("Farmer"))
            {
                var farmerView = other.GetComponent<FarmerView>();
                if (FactionCtlr == farmerView.FactionCtlr) return;
                if (_targetFarmer == null)
                {
                    _targetFarmer = farmerView;
                }
                else if (Vector2.Distance(transform.position, other.transform.position) < Vector2.Distance(transform.position, _targetFarmer.transform.position))
                {
                    _targetFarmer = farmerView;
                }
            }
        }

        private void OnVisionExit(Collider2D other)
        {
            if (other.CompareTag("Mainbase"))
            {
                _targetMainbase = null;
                return;
            }
            if (other.CompareTag("Farmer"))
            {
                var farmerView = other.GetComponent<FarmerView>();
                if (_targetFarmer == farmerView)
                {
                    _targetFarmer = null;
                }
            }
        }

        #endregion

        #endregion
    }
}