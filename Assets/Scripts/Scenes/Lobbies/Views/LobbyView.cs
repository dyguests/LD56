using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Lobbies.Entities;
using UnityEngine;

namespace Scenes.Lobbies.Views
{
    public class LobbyView : DataView<Lobby>
    {
        #region DataView<Lobby>

        public override async UniTask LoadData(Lobby data)
        {
            await base.LoadData(data);
        }

        public override async UniTask UnloadData()
        {
            await base.UnloadData();
        }

        #endregion
    }
}