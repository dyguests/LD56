using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Koyou.Commons;
using UnityEngine;
using Wars.Entities;

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

                // var creatureView = Instantiate(
                //     creatureViewPfb,
                //     transform.position + (Vector3)(cd.radius * Random.insideUnitCircle.normalized),
                //     Quaternion.identity
                // );
                // creatureView.name= "Creature";
                await UniTask.Delay(5000);
            });
        }

        private async UniTask UnloadData()
        {
            _heartbeat.Stop();
        }

        #region MainBaseView

        public void Duplicate(Faction faction, Vector3 position, bool init = false)
        {
            var instance = Instantiate(this, position, Quaternion.identity);
            instance.faction = faction;
            // todo if not init, then cost food.
            LoadData().Forget();
        }

        #endregion
    }
}