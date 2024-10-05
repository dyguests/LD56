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
            boundaryViews[0].SetBoundary(CreateRect(new Vector2(-(mapSize.x + thickness) / 2, 0), new Vector2(thickness, mapSize.y + 2 * thickness)));
            boundaryViews[1].SetBoundary(CreateRect(new Vector2(0, (mapSize.y + thickness) / 2), new Vector2(mapSize.x + 2 * thickness, thickness)));
            boundaryViews[2].SetBoundary(CreateRect(new Vector2((mapSize.x + thickness) / 2, 0), new Vector2(thickness, mapSize.y + 2 * thickness)));
            boundaryViews[3].SetBoundary(CreateRect(new Vector2(0, -(mapSize.y + thickness) / 2), new Vector2(mapSize.x + 2 * thickness, thickness)));
        }

        private static Rect CreateRect(Vector2 center, Vector2 size)
        {
            return new Rect(center - size / 2, size);
        }

        #endregion
    }
}