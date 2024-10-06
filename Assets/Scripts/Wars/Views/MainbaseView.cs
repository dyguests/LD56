using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Koyou.Commons;
using Scenes.Games.Views;
using UnityEngine;
using Wars.Entities;
using Wars.ScriptableObjects;

namespace Wars.Views
{
    public class MainbaseView : BuildingView<Mainbase>
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
                await UniTask.Delay(5000);
                var creatureSo = CreatureSos[0];
                switch (creatureSo)
                {
                    case FarmerSo farmerSo:
                    {
                        var farmerBase = farmerSo.farmerBase;

                        if (farmerBase.costFood > faction.Food.Value.current) return;
                        if (farmerBase.costPopulation > faction.Population.Value.Remaining) return;

                        faction.Food.Value -= farmerBase.costFood;
                        faction.Population.Value += farmerBase.costPopulation;

                        var farmer = Farmer.CreateFrom(farmerBase);

                        var farmerView = farmerSo.prefab.Duplicate(transform.position + (Vector3)(cd.radius * Random.insideUnitCircle.normalized));
                        farmerView.FactionCtlr = FactionCtlr;
                        farmerView.Opponent = Opponent;
                        farmerView.LoadData(farmer).Forget();
                        break;
                    }
                }
            });
        }

        private async UniTask UnloadData()
        {
            _heartbeat.Stop();
        }

        #region MainBaseView

        public FactionCtlr FactionCtlr { get; set; }
        public FactionCtlr Opponent { get; set; }

        public MainbaseView Duplicate(Faction faction, Vector3 position, bool init = false)
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