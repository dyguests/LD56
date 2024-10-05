using UnityEngine;
using Wars.Views;

namespace Scenes.Games.Views
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private MainBaseView mainBaseView;

        public MainBaseView MainBaseView
        {
            get => mainBaseView;
            set => mainBaseView = value;
        }
    }
}