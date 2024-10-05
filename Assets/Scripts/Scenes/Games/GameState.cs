using System;
using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Scenes.Games
{
    public class GameState : AppState
    {
        #region AppState

        public override async UniTask Enter()
        {
            await base.Enter();
            await SceneManager.LoadSceneAsync("Game").ToUniTask();
            var scene = Object.FindFirstObjectByType<GameScene>() ?? throw new Exception($"{nameof(GameScene)} not found");
            scene.MapName = _mapName;
            scene.RaceName = _raceName;
            await scene.Enter();
        }

        public override async UniTask Exit()
        {
            var scene = Object.FindFirstObjectByType<GameScene>() ?? throw new Exception($"{nameof(GameScene)} not found");
            await scene.Exit();
            await base.Exit();
        }

        #endregion

        #region GameState

        private string _mapName;
        private string _raceName;

        public GameState(string mapName, string raceName)
        {
            _mapName = mapName;
            _raceName = raceName;
        }

        #endregion
    }
}