using System;
using UnityEngine;

namespace Scenes.Games.Views
{
    public class ResourcesPanelView : MonoBehaviour
    {
        #region ResourcesPanelView

        [SerializeField] private ResourcePanelView foodRpv;
        [SerializeField] private ResourcePanelView populationRpv;

        private PlayerCtlr _playerCtlr;

        private IDisposable _foodDisposable;
        private IDisposable _populationDisposable;

        public void BindPlayer(PlayerCtlr playerCtlr)
        {
            _playerCtlr = playerCtlr;

            var faction = _playerCtlr.Faction;

            _foodDisposable = faction.Food.Collect((previous, current, transition) => { foodRpv.SetText(current.current.ToString()); });
            _populationDisposable = faction.Population.Collect((previous, current, transition) => { populationRpv.SetText(current.ToString()); });
        }

        public void UnbindPlayer()
        {
            _foodDisposable.Dispose();
            _populationDisposable.Dispose();
        }

        #endregion
    }
}