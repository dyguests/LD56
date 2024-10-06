using System;
using TMPro;
using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public class StatusBarView : MonoBehaviour
    {
        #region StatusBarView

        [Space] [SerializeField]
        private TMP_Text hpText;

        private IDisposable _disposable;

        public void Bind(Unit unit)
        {
            _disposable = unit.Health.Collect((previous, current, transition) => { hpText.text = current.ToString(); });
        }

        public void Unbind()
        {
            _disposable.Dispose();
        }

        #endregion
    }
}