using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Koyou.Commons;
using UnityEngine;
using Wars.Entities;
using Wars.ScriptableObjects;

namespace Wars.Views
{
    public class MainBaseView : BuildingView<MainBase>
    {
        #region MonoBehaviour

        private void OnDisable()
        {
            UnloadData().Forget();
        }

        #endregion

        [SerializeField] private List<SpawnIntent> spawnIntents;

        private Heartbeat _heartbeat;

        private Faction faction;

        private async UniTask LoadData()
        {
            spawnIntents.Add(new SpawnIntent(CreatureSos[0]));

            _heartbeat = Heartbeat.Run(async () =>
            {
                var creatureSo = CreatureSos[0];
                switch (creatureSo)
                {
                    case FarmerSo farmerSo:
                    {
                        var farmerView = farmerSo.prefab.Duplicate(transform.position + (Vector3)(cd.radius * Random.insideUnitCircle.normalized));
                        break;
                    }
                }
                await UniTask.Delay(5000);
            });
        }

        private async UniTask UnloadData()
        {
            _heartbeat.Stop();
        }

        #region MainBaseView

        public MainBaseView Duplicate(Faction faction, Vector3 position, bool init = false)
        {
            var instance = Instantiate(this, position, Quaternion.identity);
            instance.name = $"{name}{GenerateId()}";
            instance.faction = faction;
            // todo if not init, then cost food.
            instance.LoadData().Forget();

            return instance;
        }

        #endregion
    }
}