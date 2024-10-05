using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Games;
using Scenes.Lobbies.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Lobbies.Views
{
    public class LobbyUiView : DataView<Lobby>
    {
        #region DataView<Lobby>

        public override async UniTask LoadData(Lobby data)
        {
            await base.LoadData(data);
            startBtn.onClick.AddListener(StartOnClick);
        }

        public override async UniTask UnloadData()
        {
            startBtn.onClick.RemoveListener(StartOnClick);
            await base.UnloadData();
        }

        #endregion

        #region LobbyUiView

        [SerializeField]
        private Button startBtn;

        private void StartOnClick()
        {
            AppStateMachine.Instance.EnqueueState(new GameState("Map1", "Race1"));
        }

        #endregion
    }
}