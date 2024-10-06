using UnityEngine;
using Wars.Views;

namespace Scenes.Games.Views
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private MainbaseView mainbaseView;

        public MainbaseView MainbaseView
        {
            get => mainbaseView;
            set => mainbaseView = value;
        }
    }
}