using Cysharp.Threading.Tasks;
using Koyou.Commons;
using Koyou.Frameworks;
using Scenes.Lobbies;

namespace Scenes.Splashes
{
    public class SplashScene : BaseScene
    {
        #region BaseScene

        public override async UniTask Enter()
        {
            await base.Enter();
            Log.N($"Called");
            AppStateMachine.Instance.EnqueueState(new LobbyState());
        }

        public override async UniTask Exit()
        {
            Log.N($"Called");
            await base.Exit();
        }

        #endregion
    }
}