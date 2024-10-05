using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Games.Entities;
using UnityEngine;

namespace Scenes.Games
{
    public class GameScene : BaseScene
    {
        #region MonoBehaviour

        private void Start()
        {
#if UNITY_EDITOR
            if (MapName == null || RaceName == null)
            {
                MapName = "Map1";
                RaceName = "Race1";
                RunSceneFlow();
            }
#endif
        }

        #endregion

        #region BaseScene

        public override async UniTask Enter()
        {
            await base.Enter();
            await gameView.LoadData(new Game());
        }

        public override async UniTask Exit()
        {
            await gameView.UnloadData();
            await base.Exit();
        }

        #endregion

        #region GameScene

        [SerializeField]
        private GameView gameView;

        public string MapName { get; set; }
        public string RaceName { get; set; }

        #endregion
    }
}