using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Games.Entities;
using Scenes.Games.Views;
using UnityEngine;

namespace Scenes.Games
{
    public class GameView : DataView<Game>
    {
        #region DataView<Game>

        public override async UniTask LoadData(Game data)
        {
            await base.LoadData(data);
        }

        public override async UniTask UnloadData()
        {
            await base.UnloadData();
        }

        #endregion

        #region GameView

        [SerializeField]
        private MapView mapView;

        #endregion
    }
}