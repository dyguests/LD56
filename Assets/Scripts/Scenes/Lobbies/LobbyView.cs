using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Lobbies.Entities;
using Scenes.Lobbies.Views;
using UnityEngine;

namespace Scenes.Lobbies
{
    public class LobbyView : DataView<Lobby>
    {
        #region DataView<Lobby>

        public override async UniTask LoadData(Lobby data)
        {
            await base.LoadData(data);
            await uiView.LoadData(data);
        }

        public override async UniTask UnloadData()
        {
            await uiView.UnloadData();
            await base.UnloadData();
        }

        #endregion

        #region LobbyView

        [SerializeField] private LobbyUiView uiView;

        #endregion
    }
}