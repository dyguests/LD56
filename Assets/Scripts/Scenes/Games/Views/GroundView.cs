using UnityEngine;

namespace Scenes.Games.Views
{
    public class GroundView : MonoBehaviour
    {
        #region GroundView

        [SerializeField]
        private SpriteRenderer sr;

        public void SetMapSize(Vector2 mapSize)
        {
            sr.size = mapSize;
        }

        #endregion
    }
}