using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.Games.Views
{
    public class GameUiView : MonoBehaviour
    {
        private void Start()
        {
            restartBtn.onClick.AddListener(() => { SceneManager.LoadScene("Game"); });
        }

        #region GameUiView

        [SerializeField] private ResourcesPanelView resourcesPanelView;
        
        [SerializeField] private GameObject winPanel;
        [SerializeField] private TMP_Text winText;
        [SerializeField] private Button restartBtn;

        private PlayerCtlr _playerCtlr;

        private IDisposable _playerHealthDisposable;
        private IDisposable _aiHealthDisposable;

        public void BindPlayer(PlayerCtlr playerCtlr)
        {
            _playerCtlr = playerCtlr;

            resourcesPanelView.BindPlayer(playerCtlr);

            _playerHealthDisposable = playerCtlr.MainbaseView.Data.Health.Collect((previous, current, transition) =>
            {
                if (current.current > 0) return;

                _playerHealthDisposable.Dispose();
                _aiHealthDisposable.Dispose();

                winText.text = "You Lose!";
                winPanel.gameObject.SetActive(true);
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
                if (current.current > 0) return;

                _playerHealthDisposable.Dispose();
                _aiHealthDisposable.Dispose();

                winText.text = "You Win!";
                winPanel.gameObject.SetActive(true);
            });
        }

        #endregion

        public void UnbindAi() { }
    }
}