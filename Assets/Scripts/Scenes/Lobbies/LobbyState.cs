using System;
using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using UnityEngine.SceneManagement;

namespace Scenes.Lobbies
{
    public class LobbyState : AppState
    {
        #region AppState

        public override async UniTask Enter()
        {
            await base.Enter();
            await SceneManager.LoadSceneAsync("Lobby").ToUniTask();
            var scene = UnityEngine.Object.FindFirstObjectByType<LobbyScene>() ?? throw new Exception($"{nameof(LobbyScene)} not found");
            await scene.Enter();
        }

        public override async UniTask Exit()
        {
            var scene =UnityEngine. Object.FindFirstObjectByType<LobbyScene>() ?? throw new Exception($"{nameof(LobbyScene)} not found");
            await scene.Exit();
            await base.Exit();
        }

        #endregion
    }
}