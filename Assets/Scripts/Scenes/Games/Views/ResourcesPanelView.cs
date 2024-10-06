using UnityEngine;

namespace Scenes.Games.Views
{
    public class ResourcesPanelView : MonoBehaviour
    {
        #region ResourcesPanelView

        [SerializeField] private ResourcePanelView foodRpv;
        [SerializeField] private ResourcePanelView populationRpv;

        private PlayerCtlr _playerCtlr;

        public void BindPlayer(PlayerCtlr playerCtlr)
        {
            _playerCtlr = playerCtlr;

            var faction = _playerCtlr.Faction;
            
        }

        #endregion
    }
}