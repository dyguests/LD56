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
            sPrefab ??= await ResourceEx.LoadAsync<PlayerCtlr>("Factions/PlayerCtlr");
            var instance = Instantiate(sPrefab, parent);
            instance.LoadData(factionIndex, factionBase, parent);
            return instance;
        }

        private void LoadData(int factionIndex, FactionBase factionBase, Transform parent)
        {
            name = $"PlayerCtlr{factionIndex}";
            transform.localPosition = new Vector3(1 + factionIndex * 2, 0, 0);
        }
    }
}