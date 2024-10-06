using UnityEngine;

namespace Wars.Views
{
    public abstract class UnitView : MonoBehaviour
    {
        #region UnitView

        [SerializeField] protected CircleCollider2D cd;

        #endregion
    }
}