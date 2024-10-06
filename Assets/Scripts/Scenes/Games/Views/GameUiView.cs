using System;
using TMPro;
using UnityEngine;

namespace Scenes.Games.Views
{
    public class GameUiView : MonoBehaviour
    {
        #region GameUiView

        [SerializeField] private ResourcesPanelView resourcesPanelView;
        [SerializeField] private TMP_Text winText;

        private PlayerCtlr _playerCtlr;

        private IDisposable _playerHealthDisposable;
        private IDisposable _aiHealthDisposable;

        public void BindPlayer(PlayerCtlr playerCtlr)
        {
            _playerCtlr = playerCtlr;

            resourcesPanelView.BindPlayer(playerCtlr);

            _playerHealthDisposable = playerCtlr.MainbaseView.Data.Health.Collect((previous, current, transition) =>
            {
                _playerHealthDisposable.Dispose();
                _aiHealthDisposable.Dispose();

                winText.text = "You Lose!";
                winText.gameObject.SetActive(true);
            });
        }

        public void UnbindPlayer()
        {
            resourcesPanelView.UnbindPlayer();

            _playerCtlr = null;
        }

        public void BindAi(AiCtlr aiCtlr)
        {
            _aiHealthDisposable = aiCtlr.MainbaseView.Data.Health.Collect((previous, current, transition) =>
            {
                _playerHealthDisposable.Dispose();
                _aiHealthDisposable.Dispose();

                winText.text = "You Win!";
                winText.gameObject.SetActive(true);
            });
        }

        #endregion

        public void UnbindAi() { }
    }
}