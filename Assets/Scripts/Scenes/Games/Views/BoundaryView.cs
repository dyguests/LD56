using UnityEngine;

namespace Scenes.Games.Views
{
    public class BoundaryView : MonoBehaviour
    {
        #region BoundaryView

        [SerializeField]
        private BoxCollider2D cd;

        #endregion"

        public void SetBoundary(Rect rect)
        {
            transform.localPosition = rect.center;
            cd.offset = Vector2.zero;
            cd.size = rect.size;
        }
    }
}