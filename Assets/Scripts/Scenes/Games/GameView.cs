using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Games.Entities;
using Scenes.Games.Views;
using UnityEngine;
using Wars.Entities;

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

            factions = new List<Faction>();
            factions.Add(new Faction());
            factions.Add(new Faction());

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

        #endregion
    }
}