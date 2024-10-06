using UnityEngine;

namespace Scenes.Games.Views
{
    public class GameUiView : MonoBehaviour
    {
        #region GameUiView
        
        [SerializeField]
        private ResourcesPanelView resourcesPanelView;

        private PlayerCtlr _playerCtlr;

        public void BindPlayer(PlayerCtlr playerCtlr)
        {
            _playerCtlr = playerCtlr;
            
            resourcesPanelView.BindPlayer(playerCtlr);
        }

        #endregion
    }
}