using System;
using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Scenes.Lobbies
{
    public class LobbyState : AppState
    {
        #region AppState

        public override async UniTask Enter()
        {
            await base.Enter();
            await SceneManager.LoadSceneAsync("Lobby").ToUniTask();
            var scene = Object.FindFirstObjectByType<LobbyScene>() ?? throw new Exception($"{nameof(LobbyScene)} not found");
            await scene.Enter();
        }

        public override async UniTask Exit()
        {
            var scene = Object.FindFirstObjectByType<LobbyScene>() ?? throw new Exception($"{nameof(LobbyScene)} not found");
            await scene.Exit();
            await base.Exit();
        }

        #endregion
    }
}