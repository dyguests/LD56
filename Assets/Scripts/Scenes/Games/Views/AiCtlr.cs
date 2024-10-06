using System.Threading.Tasks;
using Koyou.Commons;
using Scenes.Games.Entities;
using UnityEngine;
using Wars.Entities;

namespace Scenes.Games.Views
{
    public class AiCtlr : FactionCtlr
    {
        private static AiCtlr sPrefab;

        public static async Task<AiCtlr> Generate(int factionIndex, FactionBase factionBase, Transform parent)
        {
            sPrefab ??= await Resources.LoadAsync<AiCtlr>("Factions/AiCtlr").ToUniTask<AiCtlr>();
            var instance = Instantiate(sPrefab, parent);
         await   instance.LoadData(factionIndex, factionBase, parent);
            return instance;
        }
    }
}