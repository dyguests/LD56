using UnityEngine;

namespace Scenes.Games.Views
{
    public class GameUiView : MonoBehaviour
    {
        private PlayerCtlr _playerCtlr;

        public void BindPlayer(PlayerCtlr playerCtlr)
        {
            _playerCtlr = playerCtlr;
        }
    }
}