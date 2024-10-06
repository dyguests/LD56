using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Koyou.Frameworks;
using Scenes.Games.Entities;
using Scenes.Games.Views;
using UnityEngine;
using Wars.Entities;

namespace Scenes.Games
{
    public class GameView : DataView<Game>
    {
        #region DataView<Game>

        public override async UniTask LoadData(Game data)
        {
            await base.LoadData(data);
            if (mapView == null)
            {
                // todo load map
            }

            PlayerCtlr playerCtlr = null;
            AiCtlr aiCtlr = null;

            factionCtlrs.Clear();
            for (var i = 0; i < Data.factionBases.Count; i++)
            {
                var factionBase = Data.factionBases[i];
                // todo only one of factionBase is player
                switch (factionBase.ctlrType)
                {
                    case FactionBase.CtlrType.Player:
                    {
                        playerCtlr = await PlayerCtlr.Generate(i, factionBase, transform);
                        factionCtlrs.Add(playerCtlr);
                        break;
                    }
                    case FactionBase.CtlrType.Ai:
                    {
                        aiCtlr = await AiCtlr.Generate(i, factionBase, transform);
                        factionCtlrs.Add(aiCtlr);
                        break;
                    }
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            // 暂时只管两个势力
            if (factionCtlrs.Count == 2)
            {
                factionCtlrs[0].Opponent = factionCtlrs[1];
                factionCtlrs[1].Opponent = factionCtlrs[0];
            }

            foreach (var factionCtlr in factionCtlrs)
            {
                await mapView.InitFaction(factionCtlr);
            }

            uiView.BindPlayer(playerCtlr);
            uiView.BindAi(aiCtlr);

            // cameramanView.BindPlayer(playerCtlr);
        }

        public override async UniTask UnloadData()
        {
            uiView.UnbindPlayer();
            uiView.UnbindAi();

            await base.UnloadData();
        }

        #endregion

        #region GameView

        [SerializeField] private GameUiView uiView;
        [SerializeField] private CameramanView cameramanView;
        [SerializeField] private MapView mapView;

        [Space] [SerializeField]
        private List<FactionCtlr> factionCtlrs;

        #endregion
    }
}