using System;
using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Object = UnityEngine.Object;

namespace Scenes.Splashes
{
    public class SplashState : AppState
    {
        #region AppState

        public override async UniTask Enter()
        {
            await base.Enter();
            await UniTask.Delay(200);
            var scene = Object.FindFirstObjectByType<SplashScene>() ?? throw new Exception($"{nameof(SplashScene)} not found");
            await scene.Enter();
        }

        public override async UniTask Exit()
        {
            var scene = Object.FindFirstObjectByType<SplashScene>() ?? throw new Exception($"{nameof(SplashScene)} not found");
            await scene.Exit();
            await UniTask.Delay(200);
            await base.Exit();
        }

        #endregion
    }
}