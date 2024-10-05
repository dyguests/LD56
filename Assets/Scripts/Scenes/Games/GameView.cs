using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Games.Entities;
using Scenes.Games.Views;
using UnityEngine;
using Wars.Entities;
using Wars.ScriptableObjects;
using Wars.Views;

namespace Scenes.Games
{
    public class GameView : DataView<Game>
    {
        #region DataView<Game>

        public override async UniTask LoadData(Game data)
        {
            await base.LoadData(data);
            if (mapView == null)
            {
                // todo load map
            }

            factions = new List<Faction>
            {
                new Faction(),
                new Faction(),
            };

            await mapView.InitFaction(factions[0]);
            await mapView.InitFaction(factions[1]);
        }

        public override async UniTask UnloadData()
        {
            await base.UnloadData();
        }

        #endregion

        #region GameView

        [SerializeField]
        private MapView mapView;

        private List<Faction> factions;

        [Space] [Space]
        [Header("测试用，地图自带种族")]
        [SerializeField] private RaceSo raceSo1;
        [SerializeField] private MainBaseView mainBaseView1;
        [Space]
        [SerializeField] private RaceSo raceSo2;
        [SerializeField] private MainBaseView mainBaseView2;

        #endregion
    }
}