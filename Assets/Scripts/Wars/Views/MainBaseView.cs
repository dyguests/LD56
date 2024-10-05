using System.Collections.Generic;
using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public class MainBaseView : BuildingView
    {
        [SerializeField] private List<SpawnIntent> spawnIntents;

        private void Start()
        {
            spawnIntents.Add(new SpawnIntent(CreatureSpawns[0]));
        }
    }
}