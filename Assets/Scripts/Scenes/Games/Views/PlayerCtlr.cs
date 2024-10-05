using Cysharp.Threading.Tasks;
using Koyou.Commons;
using Scenes.Games.Entities;
using UnityEngine;

namespace Scenes.Games.Views
{
    public class PlayerCtlr : FactionCtlr
    {
        private static PlayerCtlr sPrefab;

        public static async UniTask<PlayerCtlr> Generate(int factionIndex, FactionBase factionBase, Transform parent)
        {
            sPrefab ??= await Resources.LoadAsync<PlayerCtlr>("Factions/PlayerCtlr").ToUniTask<PlayerCtlr>();
            var instance = Instantiate(sPrefab, parent);
            await instance.LoadData(factionIndex, factionBase, parent);
            return instance;
        }
    }
}