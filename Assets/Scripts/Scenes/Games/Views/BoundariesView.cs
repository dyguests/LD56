using UnityEngine;

namespace Scenes.Games.Views
{
    public class BoundariesView : MonoBehaviour
    {
        #region BoundariesView

        [SerializeField]
        private BoundaryView[] boundaryViews;

        [SerializeField]
        private float thickness = 10f;

        public void SetMapSize(Vector2 mapSize)
        {
            boundaryViews[0].SetBoundary(new Rect(-(mapSize.x + thickness) / 2, 0, thickness, mapSize.y + 2 * thickness));
            boundaryViews[1].SetBoundary(new Rect(0, (mapSize.y + thickness) / 2, mapSize.x + 2 * thickness, thickness));
            boundaryViews[2].SetBoundary(new Rect((mapSize.x + thickness) / 2, 0, thickness, mapSize.y + 2 * thickness));
            boundaryViews[3].SetBoundary(new Rect(0, -(mapSize.y + thickness) / 2, mapSize.x + 2 * thickness, thickness));
        }

        #endregion
    }
}