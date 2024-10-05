using Cysharp.Threading.Tasks;
using Koyou.Commons;
using Koyou.Frameworks;
using Scenes.Lobbies.Entities;
using Scenes.Lobbies.Views;
using UnityEngine;

namespace Scenes.Lobbies
{
    public class LobbyScene : BaseScene
    {
        #region BaseScene

        public override async UniTask Enter()
        {
            await base.Enter();
            Log.N($"Called");
            var lobby = new Lobby(); // todo cache
            await lobbyView.LoadData(lobby);
        }

        public override async UniTask Exit()
        {
            await lobbyView.UnloadData();
            Log.N($"Called");
            await base.Exit();
        }

        #endregion

        #region LobbyScene

        [SerializeField] private LobbyView lobbyView;

        #endregion
    }
}