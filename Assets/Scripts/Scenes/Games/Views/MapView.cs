using System.Linq;
using Cysharp.Threading.Tasks;
using Koyou.Commons;
using UnityEngine;

namespace Scenes.Games.Views
{
    // [ExecuteAlways]
    public class MapView : MonoBehaviour
    {
        #region MonoBehaviour

#if UNITY_EDITOR
        private void OnValidate()
        {
            SetDirty();
        }
#endif

        private void SetDirty()
        {
            boundariesView.SetMapSize(mapSize);
            groundView.SetMapSize(mapSize);
        }

        #endregion

        #region MapView

        [SerializeField] private BoundariesView boundariesView;
        [SerializeField] private GroundView groundView;

        [Space] [Header("Custom")] [Space] [SerializeField]
        private Vector2 mapSize = new(100, 100);
        [SerializeField] private SpawnPoint[] spawnPoints;

        public async UniTask InitFaction(FactionCtlr factionCtlr)
        {
            var spawnPoint = spawnPoints.Where(point => point.MainBaseView == null).Random();
            if (spawnPoint == null)
            {
                Log.E($"SpawnPoint不足，无法初始化势力{factionCtlr.name}");
                return;
            }
            factionCtlr.GenerateMainBaseView(spawnPoint);
        }

        #endregion
    }
}