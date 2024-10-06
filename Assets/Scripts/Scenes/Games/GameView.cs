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

            factionCtlrs.Clear();
            for (var i = 0; i < Data.factionBases.Count; i++)
            {
                var factionBase = Data.factionBases[i];
                // todo only one of factionBase is player
                switch (factionBase.ctlrType)
                {
                    case FactionBase.CtlrType.Player:
                    {
                        var factionCtlr = await PlayerCtlr.Generate(i, factionBase, transform);
                        playerCtlr = factionCtlr;
                        uiView.BindPlayer(factionCtlr);
                        factionCtlrs.Add(factionCtlr);
                        break;
                    }
                    case FactionBase.CtlrType.Ai:
                    {
                        factionCtlrs.Add(await AiCtlr.Generate(i, factionBase, transform));
                        break;
                    }
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            foreach (var factionCtlr in factionCtlrs)
            {
                await mapView.InitFaction(factionCtlr);
            }

            // cameramanView.BindPlayer(playerCtlr);
        }

        public override async UniTask UnloadData()
        {
            uiView.UnbindPlayer();

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