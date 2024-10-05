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

        [SerializeField]
        private BoundariesView boundariesView;
        [SerializeField]
        private GroundView groundView;

        [Space]
        [Header("Custom")]
        [Space]
        [SerializeField]
        private Vector2 mapSize = new(100, 100);
        [SerializeField] private SpawnPoint[] spawnPoints;

        #endregion
    }
}