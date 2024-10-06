using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public abstract class UnitView : MonoBehaviour
    {
        #region UnitView

        [SerializeField] protected CircleCollider2D cd;

        public Unit Unit { get; set; }

        #endregion
    }
}