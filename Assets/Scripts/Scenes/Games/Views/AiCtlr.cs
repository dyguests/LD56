using System.Threading.Tasks;
using Koyou.Commons;
using Scenes.Games.Entities;
using UnityEngine;

namespace Scenes.Games.Views
{
    public class AiCtlr : FactionCtlr
    {
        private static AiCtlr sPrefab;

        public static async Task<AiCtlr> Generate(int factionIndex, FactionBase factionBase, Transform parent)
        {
            sPrefab ??= await ResourceEx.LoadAsync<AiCtlr>("Factions/AiCtlr");
            var instance = Instantiate(sPrefab, parent);
            instance.LoadData(factionIndex, factionBase, parent);
            return instance;
        }

        private void LoadData(int factionIndex, FactionBase factionBase, Transform parent)
        {
            name = $"AiCtlr{factionIndex}";
            transform.localPosition = new Vector3(1 + factionIndex * 2, 0, 0);
        }
    }
}