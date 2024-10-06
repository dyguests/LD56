using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Koyou.Commons;
using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public class MainBaseView : BuildingView
    {
        #region MonoBehaviour

        private void Start()
        {
            spawnIntents.Add(new SpawnIntent(CreatureSpawns[0]));
            LoadData().Forget();
        }

        private void OnDisable()
        {
            UnloadData().Forget();
        }

        #endregion

        [SerializeField] private List<SpawnIntent> spawnIntents;

        private Heartbeat _heartbeat;

        private async UniTask LoadData()
        {
            _heartbeat = Heartbeat.Run(async () => { await UniTask.Delay(1000); });
        }

        private async UniTask UnloadData()
        {
            _heartbeat.Stop();
        }
    }
}